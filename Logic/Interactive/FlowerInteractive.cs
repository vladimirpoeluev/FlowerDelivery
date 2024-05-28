using MigrationDataBase.Filters;
using MigrationDataBase.Interaction;
using MigrationDataBase.Records;
using System.Configuration;
using System.Data.SqlClient;

namespace Logic.Interactive
{
    public class FlowerInteractive : IRoleInteractive
    {
        public Role Get(int id)
        {
            Role flower = null;
            using(var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["data"].ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand("select * from [Flower] where Id = @id", connection);
                command.Parameters.AddWithValue("id", id);
                using(var reader = command.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        flower = new Flower((int)reader["Id"], (User)new UserInteractive().Get((int)reader["IdUser"]));
                    }
                }
            }
            return flower;
        }

        public Role[] Get()
        {
            List<Role> roles = new List<Role>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["data"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("select * from [FLower]", conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        roles.Add(new Flower((int)reader["Id"],
                                  (User)new UserInteractive().Get((int)reader["IdUser"])));
                    }
                }
            }
            return roles.ToArray();
        }

        public Role Get(FilterByUser filter)
        {
            Role flower = null;
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["data"].ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand("select * from [Flower] where IdUser = @idUser", connection);
                command.Parameters.AddWithValue("idUser", filter.User.Id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        flower = new Flower((int)reader["Id"], (User)new UserInteractive().Get((int)reader["IdUser"]));
                    }
                }
            }
            return flower;
        }
    }
}
