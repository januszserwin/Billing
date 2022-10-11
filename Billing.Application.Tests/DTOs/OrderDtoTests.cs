using System;
using Billing.Application.DTOs;
using Xunit;

namespace Billing.Application.Tests.DTOs
{
    public class OrderDtoTests
    {
        private readonly OrderDto _orderDto;

        public OrderDtoTests()
        {
            _orderDto = new OrderDto();
        }

        [Fact]
        public void TestSetAndGetId()
        {
            //Arrange
            int id = 1;
            //Act
            _orderDto.Id = id;
            //Assert
            Assert.Equal(id, _orderDto.Id);
        }

        [Fact]
        public void TestSetAndGetUserId()
        {
            //Arrange
            Guid userId = Guid.NewGuid();
            //Act
            _orderDto.UserId = userId;
            //Assert
            Assert.Equal(userId, _orderDto.UserId);
        }

        [Fact]
        public void TestSetAndGetAmount()
        {
            //Arrange
            decimal amount = 10;
            //Act
            _orderDto.Amount = amount;
            //Assert
            Assert.Equal(amount, _orderDto.Amount);
        }

        [Fact]
        public void TestSetAndGetGatewayId()
        {
            //Arrange
            int gatewayId = 1;
            //Act
            _orderDto.GatewayId = gatewayId;
            //Assert
            Assert.Equal(gatewayId, _orderDto.GatewayId);
        }

        [Fact]
        public void TestSetAndGetDescription()
        {
            //Arrange
            string description = "Test";
            //Act
            _orderDto.Description = description;
            //Assert
            Assert.Equal(description, _orderDto.Description);
        }
    }
}
