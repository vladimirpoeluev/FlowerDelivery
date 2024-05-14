using MigrationDataBase.Records;
using MigrationDataBase.Interaction;
using System.Data.SqlClient;
using System.Configuration;

namespace Logic.Interactive
{
    public class IndentityInteractive : IIdentityUserInteractive
    {
        public bool Add(IdentityUser identity)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["data"].ConnectionString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("insert into [IdentityUser](Id, Login, Password) " +
                                                        "values(@id, @login, @password)",
                                                        sqlConnection);
                sqlCommand.Parameters.AddWithValue("id", identity.Id);
                sqlCommand.Parameters.AddWithValue("login", identity.Login);
                sqlCommand.Parameters.AddWithValue("password", identity.Password);

                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public IRecord Get(int id)
        {


            try
            {
                SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["data"].ConnectionString);
                sqlConnection.Open();
                var sqlCommand = new SqlCommand("select * from [IdentityUser] where Id = @id", sqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    return new IdentityUser((int)reader["Id"], (string)reader["Login"], (string)reader["Password"]);
                }
                reader.Close();
                sqlConnection.Close();
                return null;

            }
            catch
            {
                return null;
            }


        }

        public IRecord[] Get()
        {
            throw new NotImplementedException();
        }
    }
}