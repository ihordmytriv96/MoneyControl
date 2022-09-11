namespace MoneyControl.WebAPI.Application.Services.Models
{
    public class FullRecordModel
    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public DateTime WhenSpend { get; set; }
        public decimal MoneySpend { get; set; }
        public string ExpensesType { get; set; }
    }
}
