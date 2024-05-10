using MigrationDataBase.Records;

namespace MigrationDataBase
{
    public class UserData : ManageData
    {
        public User[] GetAllUsers()
        {
            return new User[]
            {
                new User(1, "Игорь", "Ирогерв", "Y"),
                new User(2, "Игорь", "Ирогерв", "Y"),
                new User(3, "Игорь", "Ирогерв", "Y"),
                new User(4, "Игорь", "Ирогерв", "Y"),
                new User(5, "Игорь", "Ирогерв", "Y"),
            };
        }

        public User? GetUser(int id)
        {
            return GetAllUsers()[id + 1];
        }

        public User? GetUser(string login, string password)
        {
            return GetAllUsers()[0];
        }
    }
}
