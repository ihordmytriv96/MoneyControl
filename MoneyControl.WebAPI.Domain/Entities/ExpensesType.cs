using MoneyControl.WebAPI.Domain.Entities.Base;

namespace MoneyControl.WebAPI.Domain.Entities
{
    public class ExpensesType : BaseEntity
    {
        public string TypeName { get; set; } 
        public string UserId { get; set; }
    }
}
