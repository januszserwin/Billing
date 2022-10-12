using System;
using Billing.Application.Guards;
using Billing.Common.Exceptions;
using Billing.Domain;
using Xunit;

namespace Billing.Application.Tests.Guards
{
    public class OrderUserIdGuardTests
    {
        [Fact]
        public void Check_MustThrowBillingApiException_WhenIdIsDefault()
        {
            //Arrange
            var expectedMessage = "UserId should be set.";
            var order = new Order
            {
                UserId = default
            };
            var sut = new OrderUserIdGuard();

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
                UserId = Guid.NewGuid()
            };
            var sut = new OrderUserIdGuard();

            //Act
            var exception = Record.Exception(() => sut.Check(order));

            //Assert
            Assert.Null(exception);
        }
    }
}
