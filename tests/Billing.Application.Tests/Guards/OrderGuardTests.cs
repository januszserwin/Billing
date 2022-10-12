using System.Collections.Generic;
using Billing.Application.Abstractions;
using Billing.Application.Guards;
using Billing.Domain;
using Moq;
using Xunit;

namespace Billing.Application.Tests.Guards
{
    public class OrderGuardTests
    {
        [Fact]
        public void IsValidForPayment_MustCallEachRule_WhenCalledWithConfiguredRules()
        {
            //Arrange
            var orderForPaymentGuardRule = new Mock<IOrderForPaymentGuardRule>();
            List<IOrderForPaymentGuardRule> rules = new()
            {
                orderForPaymentGuardRule.Object,
                orderForPaymentGuardRule.Object
            };
            var sut = new OrderGuard(rules);
            var order = new Order
            {
                Id = 100
            };

            //Act
            sut.IsValidForPayment(order);

            //Assert
            orderForPaymentGuardRule.Verify(x=>x.Check(It.Is<Order>(
                    orderParam => orderParam.Id.Equals(order.Id)
                )), Times.Exactly(2));
        }
    }
}
