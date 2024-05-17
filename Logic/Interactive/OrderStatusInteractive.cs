using System.Data.SqlClient;
using System.Configuration;
using MigrationDataBase.Records;
using MigrationDataBase.Interaction;

namespace Logic.Interactive
{
    public class OrderStatusInteractive : IOrderStatusInteractive
    {
        public OrderStatus Get(int id)
        {
            OrderStatus result = new OrderStatus(id, "df");

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["data"].ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand("select * from [OrderStatus] where Id = @id", connection);
                command.Parameters.AddWithValue("id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        result = new OrderStatus(id, (string)reader["Name"]);
                    }
                }
            }

            return result;
        }

        public OrderStatus[] Get()
        {
            throw new NotImplementedException();
        }
    }
}
