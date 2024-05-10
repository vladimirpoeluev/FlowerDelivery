using MigrationDataBase.Records;
using MigrationDataBase.Filters;
namespace MigrationDataBase.Interaction
{
    public interface IUserInteractive : IRecordInteractive
    {
        bool Add(User user);
        User[] Get(FilterUser f);
    }
}
