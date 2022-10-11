using Billing.Application.Abstractions;
using Billing.Common.Exceptions;
using Billing.Domain;

namespace Billing.Application.Guards
{
    public class OrderAmountGuard : IOrderForPaymentGuardRule
    {
        public void Check(Order order)
        {
            if (order.Amount <= 0)
                throw new BillingApiException("Amount in order should not be equal or less than 0.");
        }
    }
}
