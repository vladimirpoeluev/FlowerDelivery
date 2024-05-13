using MigrationDataBase.Records;

namespace MigrationDataBase.Interaction
{
    public interface IIdentityUserInteractive : IRecordInteractive
    {
        bool Add(IdentityUser identity);
    }
}
