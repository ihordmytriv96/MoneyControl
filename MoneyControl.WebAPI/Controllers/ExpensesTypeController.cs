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
        private readonly IBaseMapper<ExpensesType, ExpensesTypeModel> _expencesTypeModelMapper;

        public ExpensesTypeController(IExpensesTypeManager expensesTypeManager,
            IBaseMapper<ExpensesTypeModel,ExpensesType> expencesTypeMapper,
            IBaseValidator<ExpensesType> expencesTypeValidator,
            IBaseMapper<ExpensesType, ExpensesTypeModel> expencesTypeModelMapper)
        {
            _expensesTypeManager = expensesTypeManager;
            _expencesTypeMapper = expencesTypeMapper;
            _expencesTypeValidator = expencesTypeValidator;
            _expencesTypeModelMapper = expencesTypeModelMapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetExpensesType(string id, CancellationToken token)
        {
            var expensesType = (await _expensesTypeManager.GetExpensesTypeAsync(id, token));
            var result = _expencesTypeModelMapper.Map(expensesType);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateExpensesType(ExpensesTypeModel model, CancellationToken token)
        {
            var modelMap = _expencesTypeMapper.Map(model);
            var validation = await _expencesTypeValidator.IsValidAsync(modelMap, token);
            if (!validation.Any())
            {
                return BadRequest(validation);
            }
            var result = (await _expensesTypeManager.CreateNewExpensesTypeAsync(modelMap, token)).Id;

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteExpensesType(string Id, CancellationToken token)
        {
            await _expensesTypeManager.RemoveExpensesTypeAsync(Id, token);
            return Ok("Removed successfully");
        }


    }
}
