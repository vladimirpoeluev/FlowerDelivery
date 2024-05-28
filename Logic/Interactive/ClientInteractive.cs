using MigrationDataBase.Interaction;
using MigrationDataBase.Records;
using System.Data.SqlClient;
using System.Configuration;

namespace Logic.Interactive
{
    public class ClientInteractive : IClientInteractive
    {
        public bool Add(Client client)
        {
            throw new NotImplementedException(); 
        }

        public IRecord Get(int id)
        {
            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["data"].ConnectionString);
            conn.Open();

            var command = new SqlCommand("select * from [Client] where Id = @id", conn);
            command.Parameters.AddWithValue("id", id);
            SqlDataReader reader = command.ExecuteReader();
            Client result = null;
            if(reader.Read())
            {
               result = new Client( (int)reader["Id"], 
                                    (string)reader["Name"], 
                                    (string)reader["Surname"], 
                                    (Address)new AddressInteractive().Get((int)reader["IdAddress"]));
            }
            reader.Close();
            conn.Close();
            return result;
        }

        public IRecord[] Get()
        {
            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["data"].ConnectionString);
            conn.Open();

            var command = new SqlCommand("select * from [Client]", conn);
            SqlDataReader reader = command.ExecuteReader();
            List<IRecord> records = new List<IRecord>();
            while (reader.Read())
            {
                records.Add(new Client((int)reader["Id"],
                                     (string)reader["Name"],
                                     (string)reader["Surname"],
                                     (Address)new AddressInteractive().Get((int)reader["IdAddress"])));
            }
            reader.Close();
            conn.Close();
            return records.ToArray();
        }

        public bool Set(Client client, Client newClient)
        {
            throw new NotImplementedException();
        }
    }
}
