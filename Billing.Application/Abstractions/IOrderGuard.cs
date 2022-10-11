using Billing.Domain;

namespace Billing.Application.Abstractions
{
    public interface IOrderGuard
    {
        void IsValidForPayment(Order order);
    }
}
