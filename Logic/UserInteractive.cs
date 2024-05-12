using MigrationDataBase.Records;
using MigrationDataBase.Interaction;
using MigrationDataBase.Filters;
using System.Data.SqlClient;
using System.Configuration;

namespace Logic
{
    public class UserInteractive : IUserInteractive
    {
        static readonly string _connectionString;

        static UserInteractive()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["data"].ConnectionString;
            
        }

        public bool Add(User user)
        {
            try
            {
                var connection = new SqlConnection(_connectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand("insert into [User](Name, Surname, Description) values(@Name, @Surname, @Description)", 
                                 connection);
                cmd.Parameters.AddWithValue("Name", user.Name);
                cmd.Parameters.AddWithValue("Surname", user.Surname);
                cmd.Parameters.AddWithValue("Description", user.Description);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public User[] Get(FilterUser f)
        {
            List<User> result = new List<User>();

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("select Id from [IdentityUser] " +
                                            "where login = @login and password = @password", connection);

            cmd.Parameters.AddWithValue("login", f.login);
            cmd.Parameters.AddWithValue("password", f.password);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
                return result.ToArray();
            while (reader.Read())
            {
                result.Add((User)Get((int)reader["Id"]));
            }

            return result.ToArray();
        }

        public IRecord Get(int id)
        {
            SqlConnection connection = new SqlConnection( _connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from [User] where Id = @id", connection);

            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
                return new User(id, (string)reader["Name"], (string)reader["Surname"], (string)reader["Description"]);
            return null;
        }

        public IRecord[] Get()
        {
            List<IRecord> records = new List<IRecord>();

            var connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from [User]", connection);
            
            SqlDataReader read;
            
            read = cmd.ExecuteReader();

            while(read.Read())
            {
                records.Add(new User((int)read["Id"],
                                     (string)read["Name"],
                                     (string)read["Surname"],
                                     (string)read["Description"]));
            }
            read.Close();
            return records.ToArray();
        }
    }
}