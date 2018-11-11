using Xunit;

namespace Tests
{
    public class PatternMatching
    {
        [Fact]
        public void WithoutPatternMatchingTest()
        {
            var dog = new Dog();
            if (dog is Animal)
            {
                Assert.NotNull(dog as Animal);
            }
            Assert.Null(dog as Animal);
        }

        [Fact]
        public void PatternMatchingTest()
        {
            var dog = new Dog();
            if (dog is Animal animal)
            {
                Assert.NotNull(animal);
            }
        }
    }
}