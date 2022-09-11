using MoneyControl.WebAPI.Domain.Entities.Base;

namespace MoneyControl.WebAPI.Domain.Entities
{
    public class MoneyLimiter : BaseEntity
    {
        public string ExpensesTypeId { get; set; }
        public DateTime? LimitStart { get; set; }
        public DateTime? LimitEnd { get; set; }
        public double? MoneySpent { get; set; }
        public double? MoneyLimit { get; set; }
        public string UserId { get; set; } 
    }
}
