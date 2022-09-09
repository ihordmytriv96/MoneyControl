using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyControl.WebAPI.Application.Contracts;
using MoneyControl.WebAPI.Application.Contracts.Validations;
using MoneyControl.WebAPI.Domain.Entities;
using MoneyControl.WebAPI.Host.Mappers;
using MoneyControl.WebAPI.Host.Models.ExpensesTypeModels;

namespace MoneyControl.WebAPI.Host.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ExpensesTypeController : Controller
    {
        private readonly IExpensesTypeManager _expensesTypeManager;
        private readonly IBaseMapper<ExpensesTypeModel, ExpensesType> _expencesTypeMapper;
        private readonly IBaseValidator<ExpensesType> _expencesTypeValidator;

        public ExpensesTypeController(IExpensesTypeManager expensesTypeManager,
            IBaseMapper<ExpensesTypeModel,ExpensesType> expencesTypeMapper,
            IBaseValidator<ExpensesType> expencesTypeValidator)
        {
            _expensesTypeManager = expensesTypeManager;
            _expencesTypeMapper = expencesTypeMapper;
            _expencesTypeValidator = expencesTypeValidator;
        }

        [HttpGet()]
        public async Task<ActionResult> GetExpensesType(string Id, CancellationToken token)
        {
            var result = (await _expensesTypeManager.GetExpensesType(Id, token)).Id;
            return Ok(result);
        }

        [HttpPost("create-expenses-type")]
        public async Task<ActionResult> CreateExpensesType(ExpensesTypeModel model, CancellationToken token)
        {
            var modelMap = _expencesTypeMapper.Map(model);
            var validation = await _expencesTypeValidator.IsValidAsync(modelMap, token);
            if (!validation.Any())
            {
                return BadRequest(validation);
            }
            var result = (await _expensesTypeManager.CreateNewExpensesType(modelMap, token)).Id;

            return Ok(result);
        }

        [HttpDelete("delete-expenses-type")]
        public async Task<ActionResult> DeleteExpensesType(string Id, CancellationToken token)
        {
            await _expensesTypeManager.RemoveExpensesType(Id, token);
            return Ok("Removed successfully");
        }


    }
}
