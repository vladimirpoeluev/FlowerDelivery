using MigrationDataBase;

namespace TestsFlow
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Test1();
        }

        [Test]
        public void Test1()
        {
            string result = ConfigGet.GetConnectionString("name");
            if(result == "������ �����������")
                Assert.Pass();
            Assert.Fail();
        }
    }
}