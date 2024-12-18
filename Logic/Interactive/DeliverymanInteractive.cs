﻿using MigrationDataBase.Records;
using System.Data.SqlClient;
using System.Configuration;
using MigrationDataBase.Interaction;
using MigrationDataBase.Filters;

namespace Logic.Interactive
{
    public class DeliverymanInteractive : IRoleInteractive
    {
        public Role Get(int id)
        {
            Role deliveryman = null;
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["data"].ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand("select * from [Deliveryman] where Id = @id", connection);
                command.Parameters.AddWithValue("id", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        deliveryman = new Deliveryman((int)reader["Id"], (User)new UserInteractive().Get((int)reader["IdUser"]));
                    }
                }
            }
            return deliveryman;
        }

        public Role[] Get()
        {
            List<Role> roles = new List<Role>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["data"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("select * from [Deliveryman]", conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        roles.Add(new Deliveryman((int)reader["Id"],
                                  (User)new UserInteractive().Get((int)reader["IdUser"])));
                    }
                }
            }
            return roles.ToArray();
        }

        public Role Get(FilterByUser filter)
        {
            Role deliveryman = null;
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["data"].ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand("select * from [Deliveryman] where IdUser = @idUser", connection);
                command.Parameters.AddWithValue("idUser", filter.User.Id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        deliveryman = new Deliveryman((int)reader["Id"], (User)new UserInteractive().Get((int)reader["IdUser"]));
                    }
                }
            }
            return deliveryman;
        }
    }
}
