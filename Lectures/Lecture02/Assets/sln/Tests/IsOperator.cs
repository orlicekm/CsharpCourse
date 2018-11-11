using Xunit;

namespace Tests
{
    public class IsOperator
    {
        [Fact]
        public void IsOperatorTest()
        {
            var dog = new Dog();
            Assert.False(dog is Animal);
        }
    }
}