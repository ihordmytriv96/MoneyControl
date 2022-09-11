using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyControl.WebAPI.Application.Contracts;
using MoneyControl.WebAPI.Domain.Entities;
using MoneyControl.WebAPI.Host.Mappers;
using MoneyControl.WebAPI.Host.Models.MoneyLimiterModels;

namespace MoneyControl.WebAPI.Host.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MoneyLimiterController : Controller
    {
        private readonly IBaseMapper<CreateLimitModel, MoneyLimiter> _createLimitMapper;
        private readonly IMoneyLimiterManager _moneyLimiterManager;
        private readonly IBaseMapper<MoneyLimiter, LimitModel> _limitMapper;
        private readonly IBaseMapper<UpdateLimitModel, MoneyLimiter> _updateLimitMapper;

        public MoneyLimiterController(IBaseMapper<CreateLimitModel, MoneyLimiter> createLimitMapper,
            IMoneyLimiterManager moneyLimiterManager,
            IBaseMapper<MoneyLimiter, LimitModel> limitMapper,
            IBaseMapper<UpdateLimitModel, MoneyLimiter> updateLimitMapper)
        {
            _createLimitMapper = createLimitMapper;
            _moneyLimiterManager = moneyLimiterManager;
            _limitMapper = limitMapper;
            _updateLimitMapper = updateLimitMapper;
        }

        [HttpPost]
        public async Task<ActionResult> CreateLimit([FromBody] CreateLimitModel model, CancellationToken token)
        {
            var limitMap = _createLimitMapper.Map(model);
            var limit = await _moneyLimiterManager.CreateLimitAsync(limitMap, token);
            var result = _limitMapper.Map(limit);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveLimit(string Id, CancellationToken cancellationToken)
        { 
            await _moneyLimiterManager.RemoveLimitAsync(Id, cancellationToken);
            return Ok("Removed successfully");
        }

        [HttpPatch]
        public async Task<ActionResult> UpdateLimit([FromBody] UpdateLimitModel model, CancellationToken token)
        {
            var limitForUpdate = _updateLimitMapper.Map(model);
            var updatedLimit = await _moneyLimiterManager.UpdateLimiterAsync(limitForUpdate, token);

            _limitMapper.Map(updatedLimit);

            return Ok(updatedLimit);
        }

    }
}
