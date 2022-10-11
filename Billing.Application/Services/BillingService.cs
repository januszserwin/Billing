using AutoMapper;
using Billing.Application.Abstractions;
using Billing.Application.DTOs;
using Billing.Domain;

namespace Billing.Application.Services
{
    public class BillingService : IBillingService
    {
        private readonly IMapper _mapper;
        private readonly IGatewayFactory _gatewayFactory;
        private readonly IOrderGuard _orderGuard;

        public BillingService(IMapper mapper, 
            IGatewayFactory gatewayFactory,
            IOrderGuard orderGuard)
        {
            _mapper = mapper;
            _gatewayFactory = gatewayFactory;
            _orderGuard = orderGuard;
        }

        public ReceiptDto ProcessPayment(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            _orderGuard.IsValidForPayment(order);
            var gateway = _gatewayFactory.Get(orderDto.GatewayId);

            var receipt = gateway.ProcessPayment(order);

            var receiptDto = _mapper.Map<ReceiptDto>(receipt);

            return receiptDto;
        }
    }
}
