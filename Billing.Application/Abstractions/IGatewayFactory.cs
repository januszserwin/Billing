namespace Billing.Application.Abstractions
{
    public interface IGatewayFactory
    {
        IGateway Get(int gatewayId);
    }
}
