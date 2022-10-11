using Billing.Domain;

namespace Billing.Application.Abstractions
{
    public interface IGateway
    {
        Receipt ProcessPayment(Order order);
    }
}
