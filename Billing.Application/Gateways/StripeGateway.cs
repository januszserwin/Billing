using Billing.Application.Abstractions;
using Billing.Common.Dates;
using Billing.Domain;

namespace Billing.Application.Gateways
{
    public class StripeGateway : IGateway
    {
        private readonly IDateService _dateService;

        public StripeGateway(IDateService dateService)
        {
            _dateService = dateService;
        }

        public Receipt ProcessPayment(Order order)
        {
            Receipt receipt = new()
            {
                OrderId = order.Id,
                UserId = order.UserId,
                Amount = order.Amount,
                PaymentDate = _dateService.GetCurrentUtc(),
                PaymentHandledBy = "Stripe"
            };

            return receipt;
        }
    }
}
