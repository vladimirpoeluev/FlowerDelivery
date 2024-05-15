using System.Data.SqlClient;
using System.Configuration;
using MigrationDataBase.Interaction;
using MigrationDataBase.Records;

namespace Logic.Interactive
{
    public class InteractiveFlower : IRoleInteractive
    {
        public Role Get(int id)
        {
            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["data"].ConnectionString);
            conn.Open();

            var command = new SqlCommand("select * from [Flower] where Id = @id", conn);
            command.Parameters.AddWithValue("id", id);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new Flower((int)reader["id"], (User)new UserInteractive().Get((int)reader["IdUser"]));
            }
            return null;
        }

        public Role[] Get()
        {
            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["data"].ConnectionString);
            conn.Open();

            var command = new SqlCommand("select * from [Flower]", conn);
            SqlDataReader reader = command.ExecuteReader();

            List<Role> list = new List<Role>();
            while (reader.Read())
            {
                list.Add(new Flower((int)reader["id"], (User)new UserInteractive().Get((int)reader["IdUser"])));
            }
            return list.ToArray();
        }
    }
}
