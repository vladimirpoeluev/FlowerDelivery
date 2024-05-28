using MigrationDataBase.Interaction;
using System.Data.SqlClient;
using System.Configuration;
using MigrationDataBase.Records;
using MigrationDataBase.Filters;

namespace Logic.Interactive
{
    public class OrderInteractive : IOrderInteractive
    {
        public bool Add(Order order)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["data"].ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand(@" insert into[Order] 
                                                (IdClient, Time, IdAddressShop, IdFlower, IdDeliveryman, IdPaymentStatus, IdOrderStatus)
                                                values(@idClient, @time, @idAddress, @idFlower, @idDeliveryman, @idPaymentStatus, @idOrderStatus)", 
                                                connection);
                command.Parameters.AddWithValue("idClient", order.Client.Id);
                command.Parameters.AddWithValue("time", order.Time);
                command.Parameters.AddWithValue("idAddress", order.AddressShop.Id);
                command.Parameters.AddWithValue("idFlower", order?.Flower?.Id ?? 0);
                command.Parameters.AddWithValue("idDeliveryman", order?.Deliveryman?.Id ?? 0);
                command.Parameters.AddWithValue("idPaymentStatus", 1);
                command.Parameters.AddWithValue("idOrderStatus", 1);
                if (command.ExecuteNonQuery() != 0)
                    return false;
            }
            return true;
        }

        public IRecord Get(int id)
        {
            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["data"].ConnectionString);
            conn.Open();

            var command = new SqlCommand("select * from [Order] where Id = @id", conn);
            command.Parameters.AddWithValue("id", id);
            SqlDataReader reader = command.ExecuteReader();
            Order result = null;
            Flower flower = null;
            Deliveryman deliveryman = null;
            try
            {
                flower = (Flower)new FlowerInteractive().Get((int)reader["IdFlower"]);
                deliveryman = (Deliveryman)new DeliverymanInteractive().Get((int)reader["IdDeliveryman"]);
            }
            catch
            {

            }
            if (reader.Read())
            {
                result = new Order(id, (Client)new ClientInteractive().Get((int)reader["IdClient"]),
                                    (DateTime)reader["Time"], 
                                    (AddressShop)new AddressShopInteractive().Get((int)reader["IdAddressShop"]),
                                    flower,
                                    deliveryman,
                                    new OrderStatusInteractive().Get((int)reader["IdOrderStatus"]));
            }
            reader.Close();
            return result;
        }

        public Order[] Get(FilterOrderStatus filrer)
        {
            List<Order> orders = new List<Order>();
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["data"].ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand("select * from [Order] where IdOrderStatus = @idOrderStatus", connection);
                command.Parameters.AddWithValue("idOrderStatus", filrer.IdStatus);
                using (SqlDataReader reader =  command.ExecuteReader())
                {
                    Flower flower = null;
                    Deliveryman deliveryman = null;
                    
                    try
                    {
                        flower = (Flower)new FlowerInteractive().Get((int)reader["IdFlower"]);
                        deliveryman = (Deliveryman)new DeliverymanInteractive().Get((int)reader["IdDeliveryman"]);
                    }
                    catch
                    {

                    }
                    while (reader.Read())
                    {
                        orders.Add(new Order((int)reader["id"], (Client)new ClientInteractive().Get((int)reader["IdClient"]),
                                    (DateTime)reader["Time"],
                                    (AddressShop)new AddressShopInteractive().Get((int)reader["IdAddressShop"]),
                                    flower,
                                    deliveryman,
                                    new OrderStatusInteractive().Get((int)reader["IdOrderStatus"])));
                    }
                }
            }
            return orders.ToArray();
        }

        public IRecord[] Get()
        {
            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["data"].ConnectionString);
            conn.Open();

            var command = new SqlCommand("select * from [Order]", conn);
            SqlDataReader reader = command.ExecuteReader();
            List<IRecord> records = new List<IRecord>();
            while(reader.Read())
            {
                Flower flower = null;
                Deliveryman deliveryman = null;
                

                try
                {

                    flower = (Flower)new FlowerInteractive().Get((int)reader["IdFlower"]);
                    deliveryman = (Deliveryman)new DeliverymanInteractive().Get((int)reader["IdDeliveryman"]);
                }
                catch
                {

                }
                records.Add(new Order((int)reader["id"], (Client)new ClientInteractive().Get((int)reader["IdClient"]),
                                    (DateTime)reader["Time"],
                                    (AddressShop)new AddressShopInteractive().Get((int)reader["IdAddressShop"]),
                                    flower,
                                    deliveryman,
                                    new OrderStatusInteractive().Get((int)reader["IdOrderStatus"])));
            }
            reader.Close();
            return records.ToArray();
        }

        public bool Set(Order order, Order newOrder)
        {

            using(var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["data"].ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand(@"update [Order]
                                               set  IdClient = @idClient,
                                                    Time = @time,
                                                    IdAddressShop = @idAddressShop,
                                                    IdFlower = @idFlower,
                                                    IdDeliveryman = @idDeliveryman,
                                                    IdOrderStatus = @idOrderStatus
                                                where Id = @id", conn);

                command.Parameters.AddWithValue("idClient", newOrder.Client.Id);
                command.Parameters.AddWithValue("time", newOrder.Time);
                command.Parameters.AddWithValue("idAddressShop", newOrder.AddressShop.Id);
                command.Parameters.AddWithValue("idFlower", newOrder?.Flower?.Id ?? 0);
                command.Parameters.AddWithValue("idDeliveryman", newOrder?.Deliveryman?.Id ?? 0);
                command.Parameters.AddWithValue("idPaymentStatus", 0);
                command.Parameters.AddWithValue("idOrderStatus", newOrder?.OrderStatus.Id);
                command.Parameters.AddWithValue("id", order.Id);

                command.ExecuteNonQuery();
            }

            return true;
        }
    }
}
