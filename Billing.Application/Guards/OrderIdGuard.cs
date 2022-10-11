using Billing.Application.Abstractions;
using Billing.Common.Exceptions;
using Billing.Domain;

namespace Billing.Application.Guards
{
    public class OrderIdGuard : IOrderForPaymentGuardRule
    {
        public void Check(Order order)
        {
            if (order.Id <= 0)
                throw new BillingApiException("Order id should not be equal or less than 0.");
        }
    }
}
