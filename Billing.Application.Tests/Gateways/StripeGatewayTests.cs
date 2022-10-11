using System;
using Billing.Application.Gateways;
using Billing.Common.Dates;
using Billing.Domain;
using Moq;
using Xunit;

namespace Billing.Application.Tests.Gateways
{
    public class StripeGatewayTests
    {
        [Fact]
        public void ProcessPayment_MustReturnReceipt_WhenOrderIsPassed()
        {
            //Arrange
            var currentDateTime = DateTime.UtcNow;
            var dateServiceMock = new Mock<IDateService>();
            dateServiceMock.Setup(x => x.GetCurrentUtc()).Returns(currentDateTime);
            Order order = new()
            {
                Id = 100,
                UserId = Guid.NewGuid(),
                Amount = 10,
                Description = "Test"
            };
            Receipt expectedReceipt = new()
            {
                OrderId = order.Id,
                UserId = order.UserId,
                Amount = order.Amount,
                PaymentDate = currentDateTime,
                PaymentHandledBy = "Stripe"
            };
            var sut = new StripeGateway(dateServiceMock.Object);

            //Act
            var actualReceipt = sut.ProcessPayment(order);

            //Assert
            Assert.NotNull(actualReceipt);
            Assert.Equal(expectedReceipt.OrderId, actualReceipt.OrderId);
            Assert.Equal(expectedReceipt.UserId, actualReceipt.UserId);
            Assert.Equal(expectedReceipt.Amount, actualReceipt.Amount);
            Assert.Equal(expectedReceipt.PaymentDate, actualReceipt.PaymentDate);
            Assert.Equal(expectedReceipt.PaymentHandledBy, actualReceipt.PaymentHandledBy);
        }
    }
}
