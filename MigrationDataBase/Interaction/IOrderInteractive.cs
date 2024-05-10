using MigrationDataBase.Records;
using MigrationDataBase.Filters;

namespace MigrationDataBase.Interaction
{
    public interface IOrderInteractive
    {
        bool Add(Order order);

    }
}
