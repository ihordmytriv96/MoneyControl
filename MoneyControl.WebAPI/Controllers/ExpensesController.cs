using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyControl.WebAPI.Application.Contracts;
using MoneyControl.WebAPI.Application.Services.Models;
using MoneyControl.WebAPI.Data.Filter.Contracts;
using MoneyControl.WebAPI.Domain.Contracts.Filter;
using MoneyControl.WebAPI.Domain.Contracts.Repositories;
using MoneyControl.WebAPI.Domain.Entities;
using MoneyControl.WebAPI.Host.Mappers;
using MoneyControl.WebAPI.Host.Models.ExpensesModels;

namespace MoneyControl.WebAPI.Host.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ExpensesController : Controller
    {
        private readonly IExpensesManager _expensesManager;
        private readonly IBaseMapper<CreateExpensesModel, Expenses> _expensesMapper;
        private readonly IExpensesTypeManager _expensesTypeManager;
        private readonly IUserRepository _userRepository;
        private readonly IExpensesRepository _expensesRepository;
        private readonly IEntityFilter<Expenses, IExpensesFilterModel> _expensesFilter;

        public ExpensesController(IExpensesManager expensesManager,
            IBaseMapper<CreateExpensesModel, Expenses> expensesMapper,
            IExpensesTypeManager expensesTypeManager,
            IUserRepository userRepository,
            IExpensesRepository expensesTypeRepository,
            IEntityFilter<Expenses, IExpensesFilterModel> expensesFilter)
        {
            _expensesManager = expensesManager;
            _expensesMapper = expensesMapper;
            _expensesTypeManager = expensesTypeManager;
            _userRepository = userRepository;
            _expensesRepository = expensesTypeRepository;
            _expensesFilter = expensesFilter;
        }

        [HttpGet("get-all-expenses")]
        public async Task<ActionResult> GetAllExpenses([FromQuery] ExpensesFilterModel filterModel, CancellationToken token)
        {
            var allExpenses = await _expensesRepository.FindAsync(_expensesFilter.Filter(filterModel), token);
            var result = new List<FullExpensesModel>();
            foreach (var expenses in allExpenses)
            {
                var user = await _userRepository.FindOneAsync(x => x.Id == expenses.UserId, token);
                var expensesType = await _expensesTypeManager.GetExpensesType(expenses.ExpensesTypeId, token);
                var fullExpenses = _expensesManager.CreateFullExpenses(user, expensesType, expenses);

                result.Add(fullExpenses);
            }

            if (!result.Any())
            {
                return NoContent();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPost("create-expenses")]
        public async Task<ActionResult> CreateExpenses([FromBody] CreateExpensesModel model, CancellationToken token)
        {
            var expencesMap = _expensesMapper.Map(model);
            var result = await _expensesManager.CreateExpenses(expencesMap, token);

            return Ok(result);
        }

    }
}
