using MigrationDataBase.Records;

namespace MigrationDataBase.Interaction
{
    public interface IRoleInteractive
    {
        Role Get(int id);
        Role[] Get();
    }
}
