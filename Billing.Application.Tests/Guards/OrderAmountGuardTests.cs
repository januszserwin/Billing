using Billing.Application.Guards;
using Billing.Common.Exceptions;
using Billing.Domain;
using Xunit;

namespace Billing.Application.Tests.Guards
{
    public class OrderAmountGuardTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        public void Check_MustThrowBillingApiException_WhenAmountIsZeroOrLess(decimal amount)
        {
            //Arrange
            var expectedMessage = "Amount in order should not be equal or less than 0.";
            var order = new Order
            {
                Amount = amount
            };
            var sut = new OrderAmountGuard();

            //Act
            //Assert
            var exception = Assert.Throws<BillingApiException>(() => sut.Check(order));
            Assert.Equal(expectedMessage, exception.Message);
        }

        [Fact]
        public void Check_MustNotThrowBillingApiException_WhenAmountIsGreaterThanZero()
        {
            //Arrange
            var order = new Order
            {
                Amount = 10
            };
            var sut = new OrderAmountGuard();

            //Act
            var exception = Record.Exception(() => sut.Check(order));

            //Assert
            Assert.Null(exception);
        }
    }
}
