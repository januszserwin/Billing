using Billing.Application.Abstractions;
using Billing.Common.Exceptions;
using Billing.Domain;

namespace Billing.Application.Guards
{
    public class OrderUserIdGuard : IOrderForPaymentGuardRule
    {
        public void Check(Order order)
        {
            if (order.UserId == default)
                throw new BillingApiException("UserId should be set.");
        }
    }
}
