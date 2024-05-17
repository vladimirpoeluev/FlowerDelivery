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
            throw new NotImplementedException();
        }

        public IRecord Get(int id)
        {
            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["data"].ConnectionString);
            conn.Open();

            var command = new SqlCommand("selet * from [Order] where Id = @id");
            command.Parameters.AddWithValue("id", id);
            SqlDataReader reader = command.ExecuteReader();
            Order result = null;
            if (reader.Read())
            {
                result = new Order(id, (Client)new ClientInteractive().Get((int)reader["IdClient"]),
                                    (DateTime)reader["Time"], 
                                    new AddressShopInteractive().Get((int)reader["IdAddressShop"]) as AddressShop,
                                    null, 
                                    null,
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
                var command = new SqlCommand("select * from [Order] where IdOrderStatus = @idOrderStatus", connection);
                command.Parameters.AddWithValue("idOrderStatus", filrer.IdStatus);
                using (SqlDataReader reader =  command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        orders.Add(new Order((int)reader["id"], (Client)new ClientInteractive().Get((int)reader["IdClient"]),
                                    (DateTime)reader["Time"],
                                    new AddressShopInteractive().Get((int)reader["IdAddressShop"]) as AddressShop,
                                    null,
                                    null,
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
                records.Add(new Order((int)reader["id"], (Client)new ClientInteractive().Get((int)reader["IdClient"]),
                                    (DateTime)reader["Time"],
                                    new AddressShopInteractive().Get((int)reader["IdAddressShop"]) as AddressShop,
                                    null,
                                    null,
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
                var command = new SqlCommand("", conn);

                command.Parameters.AddWithValue("idClient", newOrder.Client.Id);
                command.Parameters.AddWithValue("time", newOrder.Time);
                command.Parameters.AddWithValue("idAddressShop", newOrder.AddressShop.Id);
                command.Parameters.AddWithValue("idFlower", newOrder?.Flower.Id);
                command.Parameters.AddWithValue("idDeliveryman", newOrder?.Deliveryman.Id);
                command.Parameters.AddWithValue("idPaymentStatus", newOrder);

                command.ExecuteNonQuery();
            }

            return true;
        }
    }
}
