using Newtonsoft.Json;

namespace MoneyControl.WebAPI.Host.Models.PaymentsModels
{
    public class CreatePaymentModel
    {
        [JsonProperty("expensesTypeId")]
        public string ExpensesTypeId { get; set; }
        [JsonProperty("moneySpent")]
        public double MoneySpent { get; set; }
    }
}
