
namespace MigrationDataBase.Records
{
    public record class User(int Id, string Name, string Surname, string Description) : IRecord;
}
