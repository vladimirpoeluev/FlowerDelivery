using MigrationDataBase.Records;
using MigrationDataBase.Interaction;

namespace MigrationDataBase.Interaction
{
    public interface IAddressInteractive : IRecordInteractive
    {
        bool Add(Address address);
    }
}
