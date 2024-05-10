using MigrationDataBase.Records;

namespace MigrationDataBase.Records
{
    public record class Role(int Id, User User): IRecord;

    public record Admin(int Id, User User) : Role(Id, User);
    public record Flower(int Id, User User) : Role(Id, User);
    public record Deliveryman(int Id, User User) : Role(Id, User);
}
