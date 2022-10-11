namespace Billing.Domain
{
    public class Order
    {
        public int Id { get; init; }
        public Guid UserId { get; init; }
        public decimal Amount { get; init; }
        public string Description { get; init; }
    }
}
