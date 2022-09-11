using Newtonsoft.Json;

namespace MoneyControl.WebAPI.Host.Models.MoneyLimiterModels
{
    public class CreateLimitModel
    {
        [JsonProperty("expensesTypeId")]
        public string ExpensesTypeId { get; set; }
        [JsonProperty("limitStart")]
        public DateTime LimitStart { get; set; }
        [JsonProperty("limitEnd")]
        public DateTime LimitEnd { get; set; }
        [JsonProperty("moneyLimit")]
        public double MoneyLimit { get; set; }
    }
}
