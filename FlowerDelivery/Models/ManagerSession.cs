using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using MigrationDataBase.Records;
namespace FlowerDelivery.Models
{
    public static class ManagerSession
    {
        static Dictionary<string, User> _indentity;

        static ManagerSession()
        {
            _indentity = new Dictionary<string, User>();
        }

        public static bool RegistUser(User user, string connection)
        {

            _indentity[connection] = user;
            return true;
        }

        public static User GetUser(string connection)
        {
            try
            {
                return _indentity[connection];
            }
            catch
            {
                return null;
            }
        }

        public static Dictionary<string, User> GetUsers()
        {
            return _indentity;
        }

        public static void Close(string connection)
        {
            _indentity.Remove(connection);
        }
    }
}
