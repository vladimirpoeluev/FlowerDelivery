using System.Data.SqlClient;
using System.Configuration;
using MigrationDataBase.Interaction;
using MigrationDataBase.Records;

namespace Logic.Interactive
{
    internal class AddressInteractive : IAddressInteractive
    {
        public bool Add(Address address)
        {
            throw new NotImplementedException();
        }

        public IRecord Get(int id)
        {
            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["data"].ConnectionString);
            conn.Open();

            var command = new SqlCommand("select * from [Address] where Id = @id", conn);
            command.Parameters.AddWithValue("id", id);
            SqlDataReader reader = command.ExecuteReader();
            if(reader.Read())
            {
                var resutl = new Address((int)reader["Id"], (string)reader["Name"]);
                reader.Close();
                conn.Close();
                return resutl;
            }
           
            return null;
        }

        public IRecord[] Get()
        {
            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["data"].ConnectionString);
            conn.Open();

            var command = new SqlCommand("select * from [Address]", conn);
            SqlDataReader reader = command.ExecuteReader();
            List<IRecord> addresses = new List<IRecord>();

            while(reader.Read())
            {
                addresses.Add(new Address((int)reader["Id"], (string)reader["Name"]));
            }
            reader.Close();
            conn.Close();
            return addresses.ToArray();
        }
    }
}
