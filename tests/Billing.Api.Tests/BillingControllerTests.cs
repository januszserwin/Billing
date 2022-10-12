using System;
using Billing.Api.Controllers;
using Billing.Application.Abstractions;
using Billing.Application.DTOs;
using Billing.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Billing.Api.Tests
{
    public class BillingControllerTests
    {
        [Fact]
        public void PostPayment_MustThrowBillingApiException_WhenOrderIsNull()
        {
            //Arrange
            var expectedMessage = "Payment can`t be processed on non-existing order.";
            var billingServiceMock = new Mock<IBillingService>();
            var sut = new BillingController(billingServiceMock.Object);

            //Act

            //Assert
            var exception = Assert.Throws<BillingApiException>(() => sut.PostPayment(null));
            Assert.Equal(expectedMessage, exception.Message);
            billingServiceMock.Verify(x=>x.ProcessPayment(It.IsAny<OrderDto>()), Times.Never);
        }

        [Fact]
        public void PostPayment_MustReturnOkWIthReceipt_WhenOrderIsPassed()
        {
            //Arrange
            ReceiptDto expectedReceipt = new()
            {
                OrderId = 1,
                UserId = Guid.NewGuid(),
                Amount = 10,
                PaymentDate = DateTime.Now,
                PaymentHandledBy = "TestGateway"
            };
            var billingServiceMock = new Mock<IBillingService>();
            billingServiceMock.Setup(x => x.ProcessPayment(It.IsAny<OrderDto>()))
                .Returns(expectedReceipt);
            var sut = new BillingController(billingServiceMock.Object);

            //Act
            var actionResult = sut.PostPayment(new OrderDto());

            //Assert
            billingServiceMock.Verify(x=>x.ProcessPayment(It.IsAny<OrderDto>()), Times.Once);
            Assert.IsType<OkObjectResult>(actionResult.Result);
            var objectResult = actionResult.Result as OkObjectResult;
            Assert.NotNull(objectResult);
            var actualReceipt = (ReceiptDto)objectResult.Value;
            Assert.Equal(expectedReceipt.OrderId, actualReceipt?.OrderId);
            Assert.Equal(expectedReceipt.UserId, actualReceipt?.UserId);
            Assert.Equal(expectedReceipt.Amount, actualReceipt?.Amount);
            Assert.Equal(expectedReceipt.PaymentDate, actualReceipt?.PaymentDate);
            Assert.Equal(expectedReceipt.PaymentHandledBy, actualReceipt?.PaymentHandledBy);
        }
    }
}