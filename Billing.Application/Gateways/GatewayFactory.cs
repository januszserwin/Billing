using Billing.Application.Abstractions;
using Billing.Common.Exceptions;

namespace Billing.Application.Gateways
{
    public class GatewayFactory : IGatewayFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Dictionary<int, Func<IGateway>> _gateways = new();

        public GatewayFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _gateways.Add(1, ResolveGateway<StaxGateway>);
            _gateways.Add(2, ResolveGateway<StripeGateway>);
        }

        private IGateway ResolveGateway<T>() where T : IGateway
        {
            return (IGateway)_serviceProvider.GetService(typeof(T));
        }
        

        public IGateway Get(int gatewayId)
        {
            if (!_gateways.ContainsKey(gatewayId))
                throw new BillingApiException($"There in no gateway defined for gatewayId={gatewayId}");
            return _gateways[gatewayId]();
        }
    }
}
