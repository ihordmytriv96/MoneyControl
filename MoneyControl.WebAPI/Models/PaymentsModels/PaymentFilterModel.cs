using MoneyControl.WebAPI.Data.Filter.Contracts;
using Newtonsoft.Json;

namespace MoneyControl.WebAPI.Host.Models.PaymentsModels
{
    public class PaymentFilterModel : IPaymentFilterModel
    {
        [JsonProperty("paymentAddedDateStart")]
        public DateTime? PaymentAddedDateStart { get; set; }
        [JsonProperty("paymentAddedDateEnD")]
        public DateTime? PaymentAddedDateEnd { get; set; }
        [JsonProperty("expensesTypeId")]
        public List<string> ExpensesTypeId { get; set; }
        [JsonProperty("moneySpend")]
        public double? MoneySpend { get; set; }
    }
}
