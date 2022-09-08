using LinqKit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyControl.WebAPI.Application.Contracts;
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

        public ExpensesController(IExpensesManager expensesManager,
            IBaseMapper<CreateExpensesModel, Expenses> expensesMapper)
        {
            _expensesManager = expensesManager;
            _expensesMapper = expensesMapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllExpenses(CancellationToken token)
        {
            var result = await _expensesManager.GetAllExpenses(token);
            if (!result.Any())
            {
                return NoContent();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateExpenses([FromBody] CreateExpensesModel model, CancellationToken token)
        {
            var expencesMap = _expensesMapper.Map(model);
            var result = _expensesManager.CreateExpenses(expencesMap, token);

            return Ok(result);
        }
        
    }
}
