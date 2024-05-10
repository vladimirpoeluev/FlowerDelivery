
namespace MigrationDataBase.Records
{
    public record class Client( int Id, 
                                string Name, 
                                string Surname, 
                                Address Address
                               ) : IRecord;
}
