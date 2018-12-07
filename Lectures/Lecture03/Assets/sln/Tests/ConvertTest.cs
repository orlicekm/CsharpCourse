using Xunit;

namespace Tests
{
    public class ConvertTest
    {
        [Fact]
        public void Test()
        {
            double doubleNumber = 23.15;
            int intNumber = System.Convert.ToInt32(doubleNumber);
            bool boolNumber = System.Convert.ToBoolean(doubleNumber);
            string stringNumber = System.Convert.ToString(doubleNumber);
            char charNumber = System.Convert.ToChar(stringNumber[0]);

            Assert.Equal(23, intNumber);
            Assert.Equal(true, boolNumber);
            Assert.Equal("23.15", stringNumber);
            Assert.Equal('2', charNumber);
        }
    }
}