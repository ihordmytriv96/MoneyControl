using MoneyControl.WebAPI.Application.Contracts.Validations;
using MoneyControl.WebAPI.Domain.Contracts.Repositories;
using MoneyControl.WebAPI.Domain.Entities;

namespace MoneyControl.WebAPI.Application.Services.Validations
{
    public class ExpensesTypeValidationManager : IBaseValidator<ExpensesType>
    {
        private readonly IExpensesTypeRepository _expensesTypeRepository;

        public ExpensesTypeValidationManager(IExpensesTypeRepository expensesTypeRepository)
        {
            _expensesTypeRepository = expensesTypeRepository;
        }

        public async Task<List<string>> IsValidAsync(ExpensesType entity, CancellationToken token)
        {
            var nameIsNullOrEmpty = string.IsNullOrEmpty(entity.TypeName);
            var isInDataBase = await _expensesTypeRepository.FindAsync(x => x.TypeName == entity.TypeName, token) != null;

            var errorList = new List<string>();

            if (nameIsNullOrEmpty)
            {
                var message = "Name cannot be empty";
                errorList.Add(message);
            }
            else if (isInDataBase)
            {
                var message = "This type is alreary exist";
                errorList.Add(message);
            }

            return errorList;
        }
    }
}
