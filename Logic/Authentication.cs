using MigrationDataBase.Records;
using MigrationDataBase.Filters;
using Logic.Interactive;

namespace Logic
{
    public class Authentication
    {

        public User Lout(string login, string password)
        {
            UserInteractive loginInteractive = new UserInteractive();
            try
            {
                return loginInteractive.Get(new FilterUser(login, password))[0];
            }
            catch 
            {
                return null;
            }

            
        }
    }
}
