using MigrationDataBase.Records;
using MigrationDataBase.Filters;

namespace MigrationDataBase.Interaction
{
    public interface IClientInteractive : IRecordInteractive
    {
        bool Add(Client client);
        bool Set(Client client, Client newClient);
    }
}
