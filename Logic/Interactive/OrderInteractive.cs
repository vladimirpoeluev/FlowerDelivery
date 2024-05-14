using MigrationDataBase.Interaction;
using System.Data.SqlClient;
using System.Configuration;
using MigrationDataBase.Records;
using System;

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
                                    null);
            }
            reader.Close();
            return result;
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
                                    null));
            }
            reader.Close();
            return records.ToArray();
        }

        public bool Set(Order order, Order newOrder)
        {
            throw new NotImplementedException();
        }
    }
}
