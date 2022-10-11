using AutoMapper;
using Billing.Application.DTOs;
using Billing.Domain;

namespace Billing.Application
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            // Source -> Target
            CreateMap<OrderDto, Order>();
            CreateMap<Receipt, ReceiptDto>();
        }
    }
}
