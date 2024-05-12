using MigrationDataBase.Records;
using MigrationDataBase.Filters;

namespace MigrationDataBase.Interaction
{
    internal interface IClientInteractive : IRecordInteractive
    {
        bool Add(Client client);
        bool Set(Client client, Client newClient);
    }
}
