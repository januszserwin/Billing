using Billing.Application.DTOs;

namespace Billing.Application.Abstractions
{
    public interface IBillingService
    {
        ReceiptDto ProcessPayment(OrderDto order);
    }
}
