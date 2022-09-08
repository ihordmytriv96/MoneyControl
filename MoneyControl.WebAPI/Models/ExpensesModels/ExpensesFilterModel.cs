using MoneyControl.WebAPI.Data.Filter.Contracts;
using Newtonsoft.Json;

namespace MoneyControl.WebAPI.Host.Models.ExpensesModels
{
    public class ExpensesFilterModel : IExpensesFilterModel
    {
        [JsonProperty("expensesAddedDateStart")]
        public DateTime? ExpensesAddedDateStart { get; set; }
        [JsonProperty("expensesAddedDateEnD")]
        public DateTime? ExpensesAddedDateEnd { get; set; }
        [JsonProperty("expensesTypeId")]
        public List<string> ExpensesTypeId { get; set; }
        [JsonProperty("moneySpend")]
        public decimal? MoneySpend { get; set; }
    }
}
