using Newtonsoft.Json;

namespace MoneyControl.WebAPI.Host.Models.ExpensesModels
{
    public class CreateExpensesModel
    {
        [JsonProperty("expensesTypeId")]
        public string ExpensesTypeId { get; set; }
        [JsonProperty("moneySpent")]
        public decimal MoneySpent { get; set; }
    }
}
