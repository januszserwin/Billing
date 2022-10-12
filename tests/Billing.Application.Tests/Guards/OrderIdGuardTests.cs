using Billing.Application.Guards;
using Billing.Common.Exceptions;
using Billing.Domain;
using Xunit;

namespace Billing.Application.Tests.Guards
{
    public class OrderIdGuardTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        public void Check_MustThrowBillingApiException_WhenIdIsZeroOrLess(int id)
        {
            //Arrange
            var expectedMessage = "Order id should not be equal or less than 0.";
            var order = new Order
            {
                Id = id
            };
            var sut = new OrderIdGuard();

            //Act
            //Assert
            var exception = Assert.Throws<BillingApiException>(() => sut.Check(order));
            Assert.Equal(expectedMessage, exception.Message);
        }

        [Fact]
        public void Check_MustNotThrowBillingApiException_WhenIdIsGreaterThanZero()
        {
            //Arrange
            var order = new Order
            {
                Id = 10
            };
            var sut = new OrderIdGuard();

            //Act
            var exception = Record.Exception(() => sut.Check(order));

            //Assert
            Assert.Null(exception);
        }
    }
}
