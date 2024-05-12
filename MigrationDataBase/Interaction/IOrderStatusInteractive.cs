using MigrationDataBase.Records;

namespace MigrationDataBase.Interaction
{
    public interface IOrderStatusInteractive
    {
        OrderStatus Get(int id);
        OrderStatus[] Get();
    }
}
