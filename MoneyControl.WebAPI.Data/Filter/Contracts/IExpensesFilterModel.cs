namespace MoneyControl.WebAPI.Data.Filter.Contracts
{
    public interface IExpensesFilterModel
    {
        public DateTime? ExpensesAddedDateStart { get; set; }
        public DateTime? ExpensesAddedDateEnd { get; set; }
        public List<string> ExpensesTypeId { get; set; }
        public decimal? MoneySpend { get; set; }
    }
}
