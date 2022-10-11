namespace Billing.Application.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }
        public int GatewayId { get; set; }
        public string Description { get; set; }
    }
}
