using Billing.Application.Abstractions;
using Billing.Application.DTOs;
using Billing.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Billing.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillingController : ControllerBase
    {
        private readonly IBillingService _billingService;

        public BillingController(IBillingService billingService)
        {
            _billingService = billingService;
        }

        [HttpPost]
        public ActionResult<ReceiptDto> PostPayment(OrderDto order)
        {
            if (order == null)
                throw new BillingApiException("Payment can`t be processed on non-existing order.");

            var receipt = _billingService.ProcessPayment(order);

            return Ok(receipt);
        }
    }
}
