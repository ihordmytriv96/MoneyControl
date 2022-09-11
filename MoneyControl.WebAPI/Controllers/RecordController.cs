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
    public class RecordController : Controller
    {
        private readonly IRecordManager _expensesManager;
        private readonly IBaseMapper<CreateRecordModel, Record> _expensesMapper;
        private readonly IExpensesTypeManager _expensesTypeManager;
        private readonly IUserRepository _userRepository;
        private readonly IRecordRepository _expensesRepository;
        private readonly IEntityFilter<Record, IExpensesFilterModel> _expensesFilter;

        public RecordController(IRecordManager expensesManager,
            IBaseMapper<CreateRecordModel, Record> expensesMapper,
            IExpensesTypeManager expensesTypeManager,
            IUserRepository userRepository,
            IRecordRepository expensesTypeRepository,
            IEntityFilter<Record, IExpensesFilterModel> expensesFilter)
        {
            _expensesManager = expensesManager;
            _expensesMapper = expensesMapper;
            _expensesTypeManager = expensesTypeManager;
            _userRepository = userRepository;
            _expensesRepository = expensesTypeRepository;
            _expensesFilter = expensesFilter;
        }

        [HttpGet("get-all-expenses")]
        public async Task<ActionResult> GetAllExpenses([FromQuery] RecordFilterModel filterModel, CancellationToken token)
        {
            var allExpenses = await _expensesRepository.FindAsync(_expensesFilter.Filter(filterModel), token);
            var result = new List<FullRecordModel>();
            foreach (var expenses in allExpenses)
            {
                var user = await _userRepository.FindOneAsync(x => x.Id == expenses.UserId, token);
                var expensesType = await _expensesTypeManager.GetExpensesTypeAsync(expenses.ExpensesTypeId, token);
                var fullExpenses = _expensesManager.CreateFullRecordModel(user, expensesType, expenses);

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
        public async Task<ActionResult> CreateExpenses([FromBody] CreateRecordModel model, CancellationToken token)
        {
            var expencesMap = _expensesMapper.Map(model);
            var result = await _expensesManager.CreateRecordAsync(expencesMap, token);

            return Ok(result);
        }

    }
}
