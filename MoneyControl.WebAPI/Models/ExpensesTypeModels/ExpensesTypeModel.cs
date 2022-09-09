using Newtonsoft.Json;

namespace MoneyControl.WebAPI.Host.Models.ExpensesTypeModels
{
    public class ExpensesTypeModel
    {
        [JsonProperty("typeName")]
        public string TypeName { get; set; }
    }
}
