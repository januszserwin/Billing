using System;
using Billing.Application.Gateways;
using Billing.Common.Dates;
using Billing.Common.Exceptions;
using Moq;
using Xunit;

namespace Billing.Application.Tests.Gateways
{
    public class GatewayFactoryTests
    {
        [Fact]
        public void Get_MustThrowBillingApiException_WhenIdForNonExistingGatewayIsPassed()
        {
            //Arrange
            var nonExistingGatewayId = 100;
            var expectedMessage = $"There in no gateway defined for gatewayId={nonExistingGatewayId}";
            var serviceProviderMock = new Mock<IServiceProvider>();
            var sut = new GatewayFactory(serviceProviderMock.Object);

            //Act
            //Assert
            var exception = Assert.Throws<BillingApiException>(() => sut.Get(nonExistingGatewayId));
            Assert.Equal(expectedMessage, exception.Message);
            serviceProviderMock.Verify(x=>x.GetService(It.IsAny<Type>()), Times.Never);
        }

        [Theory]
        [InlineData(1, typeof(StaxGateway))]
        [InlineData(2, typeof(StripeGateway))]
        public void Get_MustReturnAGateway_WhenProperGatewayIdIsPassed(int gatewayId, Type expectedGatewayType)
        {
            //Arrange
            var serviceProviderMock = new Mock<IServiceProvider>();
            var dateServiceMock = new Mock<IDateService>();
            serviceProviderMock.Setup(x => x.GetService(It.IsAny<Type>()))
                .Returns((Type type) => Activator.CreateInstance(type, dateServiceMock.Object));
            var sut = new GatewayFactory(serviceProviderMock.Object);

            //Act
            var actualGateway = sut.Get(gatewayId);

            //Assert
            serviceProviderMock.Verify(x=>x.GetService(It.IsAny<Type>()), Times.Once);
            Assert.Equal(expectedGatewayType, actualGateway.GetType());
        }
    }
}