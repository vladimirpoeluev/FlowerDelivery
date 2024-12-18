﻿using System.Configuration;
using System.Data.SqlClient;
using MigrationDataBase.Interaction;
using MigrationDataBase.Records;

namespace Logic.Interactive
{
    public class AddressShopInteractive : IAddressInteractive
    {
        public bool Add(Address address)
        {
            throw new NotImplementedException();
        }

        public IRecord Get(int id)
        {
            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["data"].ConnectionString);
            conn.Open();

            var command = new SqlCommand("select * from [AddressShop] where Id = @id", conn);
            command.Parameters.AddWithValue("id", id);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new AddressShop((int)reader["Id"], (string)reader["Name"]);
            }
            reader.Close();
            conn.Close();
            return new AddressShop(id, "Lf");
        }

        public IRecord[] Get()
        {
            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["data"].ConnectionString);
            conn.Open();

            var command = new SqlCommand("select * from [AddressShop]", conn);
            SqlDataReader reader = command.ExecuteReader();
            List<IRecord> addresses = new List<IRecord>();

            while (reader.Read())
            {
                addresses.Add(new AddressShop((int)reader["Id"], (string)reader["Name"]));
            }
            reader.Close();
            conn.Close();
            return addresses.ToArray();
        }
    }
}
