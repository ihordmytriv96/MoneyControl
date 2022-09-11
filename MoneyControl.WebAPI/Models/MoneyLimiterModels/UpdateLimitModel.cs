using Newtonsoft.Json;

namespace MoneyControl.WebAPI.Host.Models.MoneyLimiterModels
{
    public class UpdateLimitModel
    {
        [JsonProperty("limitId")]
        public string LimitId { get; set; }
        [JsonProperty("newExpensesTypeId")]
        public string NewExpensesTypeId { get; set; } = string.Empty;
        [JsonProperty("newLimitStart")]
        public DateTime? NewLimitStart { get; set; }
        [JsonProperty("newLimitEnd")]
        public DateTime? NewLimitEnd { get; set; }
        [JsonProperty("newMoneyLimit")]
        public double? NewMoneyLimit { get; set; }
    }
}
