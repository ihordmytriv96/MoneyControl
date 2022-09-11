using MoneyControl.WebAPI.Host.Models.ExpensesTypeModels;
using MoneyControl.WebAPI.Host.Models.UserModels;
using Newtonsoft.Json;

namespace MoneyControl.WebAPI.Host.Models.ExpensesModels
{
    public class PaymentModel
    {
        [JsonProperty("userName")]
        public UserNameModel UserName { get; set; }
        [JsonProperty("whenSpent")]
        public DateTime WhenSpent { get; set; }
        [JsonProperty("expensesType")]
        public ExpensesTypeModel ExpensesType {get;set;}
        [JsonProperty("moneySpent")]
        public decimal MoneySpent { get; set; }
    }
}
