using Billing.Application.Abstractions;
using Billing.Domain;

namespace Billing.Application.Guards
{
    public class OrderGuard : IOrderGuard
    {
        private readonly IEnumerable<IOrderForPaymentGuardRule> _guardRules;

        public OrderGuard(IEnumerable<IOrderForPaymentGuardRule> guardRules)
        {
            _guardRules = guardRules;
        }

        public void IsValidForPayment(Order order)
        {
            foreach (var orderForPaymentGuardRule in _guardRules)
            {
                orderForPaymentGuardRule.Check(order);
            }
        }
    }
}
