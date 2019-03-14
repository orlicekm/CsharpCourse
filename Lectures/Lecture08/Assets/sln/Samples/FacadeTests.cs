using Samples.Facade;
using Xunit;

namespace Samples
{
    public class FacadeTests
    {
        private readonly MortgageFacade mortgageFacadeSUT = new MortgageFacade();

        [Fact]
        public void CustomerTest()
        {
            var customer = new Customer("Ann McKinsey");
            var eligible = mortgageFacadeSUT.IsEligible(customer, 125000);
            Assert.True(eligible);
        }
    }
}