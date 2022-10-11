using System;
using AutoMapper;
using Billing.Application.Abstractions;
using Billing.Application.DTOs;
using Billing.Application.Services;
using Billing.Domain;
using Moq;
using Xunit;

namespace Billing.Application.Tests.Services
{
    public class BillingServiceTests
    {
        [Fact]
        public void ProcessPayment_MustCallProcessPaymentOnSelectedGatewayAndReturnReceipt_WhenCalled()
        {
            //Arrange
            Order order = new()
            {
                Id = 99
            };
            var expectedReceiptDto = new ReceiptDto();

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<Order>(It.IsAny<OrderDto>()))
                .Returns(order);
            mapperMock.Setup(x => x.Map<ReceiptDto>(It.IsAny<Receipt>()))
                .Callback( (object receiptObj) =>
                {
                    Receipt receipt = (Receipt) receiptObj;
                    expectedReceiptDto.OrderId = receipt.OrderId;
                    expectedReceiptDto.PaymentHandledBy = receipt.PaymentHandledBy;
                })
                .Returns(expectedReceiptDto);

            var orderGuardMock = new Mock<IOrderGuard>();
            var gatewayFactoryMock = new Mock<IGatewayFactory>();
            gatewayFactoryMock.Setup(x => x.Get(It.IsAny<int>()))
                .Returns(new TestGateway());

            var sut = new BillingService(mapperMock.Object, gatewayFactoryMock.Object, orderGuardMock.Object);

            //Act
            var actualReceiptDto = sut.ProcessPayment(new OrderDto());

            //Assert
            mapperMock.Verify(x=>x.Map<Order>(It.IsAny<OrderDto>()), Times.Once);
            gatewayFactoryMock.Verify(x=>x.Get(It.IsAny<int>()), Times.Once);
            mapperMock.Verify(x=>x.Map<ReceiptDto>(It.IsAny<Receipt>()), Times.Once);
            Assert.Equal(expectedReceiptDto.OrderId, actualReceiptDto.OrderId);
            Assert.Equal(expectedReceiptDto.PaymentHandledBy, actualReceiptDto.PaymentHandledBy);
        }

        private class TestGateway : IGateway
        {
            public Receipt ProcessPayment(Order order)
            {
                Receipt receipt = new()
                {
                    OrderId = order.Id,
                    PaymentHandledBy = "Test"
                };

                return receipt;
            }
        }
        
    }
}
