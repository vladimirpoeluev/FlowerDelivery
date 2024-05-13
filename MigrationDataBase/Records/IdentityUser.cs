
namespace MigrationDataBase.Records
{
    public record class IdentityUser(int Id, string Login, string Password) : IRecord;
}
