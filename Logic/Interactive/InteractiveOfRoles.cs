using MigrationDataBase.Interaction;
using MigrationDataBase.Records;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection.PortableExecutable;

namespace Logic.Interactive
{
    public class InteractiveOfRoles : IRoleInteractive
    {
        public Role Get(int id)
        {
            throw new NotImplementedException();
        }

        public Role[] Get()
        {
            throw new NotImplementedException();
        }

        public bool Check(User user, Role role)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["data"].ConnectionString);
            conn.Open();
            SqlCommand command;
            if (role is Admin)
                command = new SqlCommand("select * from [Admin] where IdUser = @iduser", conn);
            else if (role is Flower)
                command = new SqlCommand("select * from [Flower] where IdUser = @iduser", conn);
            else
                command = new SqlCommand("select * from [Deliveryman] where IdUser = @iduser", conn);
            command.Parameters.AddWithValue("iduser", user.Id);

            var reader = command.ExecuteReader();
            if(reader.Read())
            {
                reader.Close();
                conn.Close();
                return true;
            }
            reader.Close();
            conn.Close();
            return false;
        }
    }
}
