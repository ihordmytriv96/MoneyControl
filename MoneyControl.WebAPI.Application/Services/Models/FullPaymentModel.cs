namespace MoneyControl.WebAPI.Application.Services.Models
{
    public class FullPaymentModel
    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public DateTime WhenSpend { get; set; }
        public double MoneySpend { get; set; }
        public string ExpensesType { get; set; }
    }
}
