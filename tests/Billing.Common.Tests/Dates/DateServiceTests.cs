using System;
using Billing.Common.Dates;
using Xunit;

namespace Billing.Common.Tests.Dates
{
    public class DateServiceTests
    {
        [Fact]
        public void GetCurrentUtc_MustReturnDateTime_WhenCalled()
        {
            //Arrange
            var sut = new DateService();

            //Act
            var currentDateTime = sut.GetCurrentUtc();

            //Assert
            Assert.IsType<DateTime>(currentDateTime);
        }
    }
}