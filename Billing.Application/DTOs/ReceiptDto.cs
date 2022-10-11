namespace Billing.Application.DTOs
{
    public class ReceiptDto
    {
        public int OrderId { get; set; }
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentHandledBy { get; set; }
    }
}
