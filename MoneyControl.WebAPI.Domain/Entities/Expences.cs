using MoneyControl.WebAPI.Domain.Entities.Base;

namespace MoneyControl.WebAPI.Domain.Entities
{
    public class Expences : BaseEntity
    {
        public DateTime WhenSpent { get; set; }
        public string ExpencesTypeId { get; set; }
        public string UserId { get; set; }
        public decimal MoneySpent { get; set; }
    }
}
