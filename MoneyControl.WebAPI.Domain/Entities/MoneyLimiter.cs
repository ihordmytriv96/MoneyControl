using MoneyControl.WebAPI.Domain.Entities.Base;

namespace MoneyControl.WebAPI.Domain.Entities
{
    public class MoneyLimiter : BaseEntity
    {
        public string ExpensesTypeId { get; set; }
        public DateTime LimitStart { get; set; }
        public DateTime LimitEnd { get; set; }
        public decimal MoneySpent { get; set; }
        public decimal MoneyLimit { get; set; }
    }
}
