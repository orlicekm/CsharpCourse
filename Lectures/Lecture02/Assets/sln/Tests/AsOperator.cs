using Xunit;

namespace Tests
{
    public class AsOperator
    {
        [Fact]
        public void AsOperatorTest()
        {
            var dog = new Dog();
            Assert.Null(dog as Animal);
        }
    }
}