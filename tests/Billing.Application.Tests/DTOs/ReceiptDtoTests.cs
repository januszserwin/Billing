using System;
using Billing.Application.DTOs;
using Xunit;

namespace Billing.Application.Tests.DTOs
{
    public class ReceiptDtoTests
    {
        private readonly ReceiptDto _receiptDto;

        public ReceiptDtoTests()
        {
            _receiptDto = new ReceiptDto();
        }

        [Fact]
        public void TestSetAndGetOrderId()
        {
            //Arrange
            int orderId = 1;
            //Act
            _receiptDto.OrderId = orderId;
            //Assert
            Assert.Equal(orderId, _receiptDto.OrderId);
        }

        [Fact]
        public void TestSetAndGetUserId()
        {
            //Arrange
            Guid userId = Guid.NewGuid();
            //Act
            _receiptDto.UserId = userId;
            //Assert
            Assert.Equal(userId, _receiptDto.UserId);
        }

        [Fact]
        public void TestSetAndGetAmount()
        {
            //Arrange
            decimal amount = 10;
            //Act
            _receiptDto.Amount = amount;
            //Assert
            Assert.Equal(amount, _receiptDto.Amount);
        }

        [Fact]
        public void TestSetAndGetPaymentDate()
        {
            //Arrange
            DateTime paymentDate = DateTime.Now;
            //Act
            _receiptDto.PaymentDate = paymentDate;
            //Assert
            Assert.Equal(paymentDate, _receiptDto.PaymentDate);
        }

        [Fact]
        public void TestSetAndGetPaymentHandledBy()
        {
            //Arrange
            string paymentHandledBy = "Test";
            //Act
            _receiptDto.PaymentHandledBy = paymentHandledBy;
            //Assert
            Assert.Equal(paymentHandledBy, _receiptDto.PaymentHandledBy);
        }
    }
}
