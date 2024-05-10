
namespace MigrationDataBase.Records
{
    public record class Order
                               ( 
                                int Id, 
                                Client Client, 
                                DateTime Time,
                                AddressShop AddressShop,
                                Flower Flower,
                                Deliveryman Deliveryman
                               ) : IRecord ;
}
