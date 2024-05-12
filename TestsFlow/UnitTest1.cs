using MigrationDataBase;
using Logic;

namespace TestsFlow
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Test1(int i)
        {

            Assert.That(i, Is.EqualTo(1), "Число должно быть равно 1");
            
        }
    }
}