using Billing.Domain;

namespace Billing.Application.Abstractions
{
    public interface IOrderForPaymentGuardRule
    {
        void Check(Order order);
    }
}
