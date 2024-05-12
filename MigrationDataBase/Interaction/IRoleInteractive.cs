using MigrationDataBase.Records;

namespace MigrationDataBase.Interaction
{
    internal interface IRoleInteractive
    {
        Role Get(int id);
        Role[] Get();
    }
}
