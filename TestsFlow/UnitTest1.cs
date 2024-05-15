using MigrationDataBase;
using Logic;
using MigrationDataBase.Records;
using Logic.Interactive;

namespace TestsFlow
{
    public class Tests
    {
        AddressShopInteractive address = new AddressShopInteractive();
        [SetUp]
        public void Setup()
        {
            address = new AddressShopInteractive();
        }


        [Test]
        [TestCase(1, "ул. Немедлелко д. 90")]
        public void TestsCheckAddress(int iDAddress, string nameAddress)
        {
            
            string result = ((AddressShop)address?.Get(iDAddress))?.Name;

            Assert.That(result, Is.EqualTo(nameAddress), $"Адрес должен быть равен {nameAddress}");
        }
    }
}