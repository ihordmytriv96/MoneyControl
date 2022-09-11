using MoneyControl.WebAPI.Host.Models.ExpensesTypeModels;
using Newtonsoft.Json;

namespace MoneyControl.WebAPI.Host.Models.MoneyLimiterModels
{
    public class LimitModel
    {
        [JsonProperty("expensesTypeId")]
        public string ExpensesTypeId { get; set; }
        [JsonProperty("expensesTypeModel")]
        public ExpensesTypeModel expensesTypeModel { get; set; }
        [JsonProperty("limitStart")]
        public DateTime? LimitStart { get; set; }
        [JsonProperty("limitEnd")]
        public DateTime? LimitEnd { get; set; }
        [JsonProperty("moneySpent")]
        public double? MoneySpent { get; set; }
        [JsonProperty("moneyLimit")]
        public double? MoneyLimit { get; set; }
    }
}
