using MoneyControl.WebAPI.Data.Filter.Contracts;
using Newtonsoft.Json;

namespace MoneyControl.WebAPI.Host.Models.ExpensesTypeModels
{
    public class ExpensesTypeFilterModel : IExpensesTypeFilterModel
    {
        [JsonProperty("expensesTypeName")]
        public string ExpensesTypeName { get; set; }
    }
}
