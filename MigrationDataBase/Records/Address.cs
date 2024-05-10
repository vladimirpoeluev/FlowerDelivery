
namespace MigrationDataBase.Records
{
    public record class Address(int Id, string Name) : IRecord;

    public record class AddressShop(int Id, string Name) : Address(Id, Name);
}
