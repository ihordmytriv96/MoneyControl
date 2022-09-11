using MoneyControl.WebAPI.Domain.Entities.Base;

namespace MoneyControl.WebAPI.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public DateTime WhenSpent { get; set; }
        public string ExpensesTypeId { get; set; }
        public string UserId { get; set; }
        public double MoneySpent { get; set; }
    }
}
