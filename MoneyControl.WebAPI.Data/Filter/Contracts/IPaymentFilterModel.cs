namespace MoneyControl.WebAPI.Data.Filter.Contracts
{
    public interface IPaymentFilterModel
    {
        public DateTime? PaymentAddedDateStart { get; set; }
        public DateTime? PaymentAddedDateEnd { get; set; }
        public List<string> ExpensesTypeId { get; set; }
        public double? MoneySpend { get; set; }
    }
}
