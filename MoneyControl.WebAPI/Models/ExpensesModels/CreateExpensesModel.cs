namespace MoneyControl.WebAPI.Host.Models.ExpensesModels
{
    public class CreateExpensesModel
    {
        public string ExpensesTypeId { get; set; }
        public decimal MoneySpent { get; set; }
    }
}
