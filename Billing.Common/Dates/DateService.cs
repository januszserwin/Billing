namespace Billing.Common.Dates
{
    public class DateService : IDateService
    {
        public DateTime GetCurrentUtc()
        {
            return DateTime.UtcNow;
        }
    }
}
