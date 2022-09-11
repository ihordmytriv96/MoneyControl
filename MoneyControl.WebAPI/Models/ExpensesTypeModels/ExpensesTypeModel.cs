using Newtonsoft.Json;

namespace MoneyControl.WebAPI.Host.Models.ExpensesTypeModels
{
    public class ExpensesTypeModel
    {
        [JsonProperty("expensesTypeId")]
        public string ExpensesTypeId { get; set; }
        [JsonProperty("typeName")]
        public string TypeName { get; set; }
    }
}
