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

        public static bool RegistUser(string username, string password, string connection)
        {

            _indentity[connection] = new User(1, username, password, username + ' ' + password);
            return true;
        }

        public static User GetUser(string connection)
        {
            return _indentity[connection];
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
