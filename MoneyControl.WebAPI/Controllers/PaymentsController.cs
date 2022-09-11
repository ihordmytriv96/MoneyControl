using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyControl.WebAPI.Application.Contracts;
using MoneyControl.WebAPI.Application.Services.Models;
using MoneyControl.WebAPI.Data.Filter.Contracts;
using MoneyControl.WebAPI.Domain.Contracts.Filter;
using MoneyControl.WebAPI.Domain.Contracts.Repositories;
using MoneyControl.WebAPI.Domain.Entities;
using MoneyControl.WebAPI.Host.Mappers;
using MoneyControl.WebAPI.Host.Models.PaymentsModels;

namespace MoneyControl.WebAPI.Host.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : Controller
    {
        private readonly IPaymentsManager _paymentsManager;
        private readonly IBaseMapper<CreatePaymentModel, Payment> _createPaymentMapper;
        private readonly IExpensesTypeManager _expensesTypeManager;
        private readonly IUserRepository _userRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IEntityFilter<Payment, IPaymentFilterModel> _paymentFilter;

        public PaymentsController(IPaymentsManager paymentsManager,
            IBaseMapper<CreatePaymentModel, Payment> createPaymentMapper,
            IExpensesTypeManager expensesTypeManager,
            IUserRepository userRepository,
            IPaymentRepository paymentRepository,
            IEntityFilter<Payment, IPaymentFilterModel> paymentFilter)
        {
            _paymentsManager = paymentsManager;
            _createPaymentMapper = createPaymentMapper;
            _expensesTypeManager = expensesTypeManager;
            _userRepository = userRepository;
            _paymentRepository = paymentRepository;
            _paymentFilter = paymentFilter;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllPayments([FromQuery] PaymentFilterModel filterModel, CancellationToken token)
        {
            var allPayments = await _paymentRepository.FindAsync(_paymentFilter.Filter(filterModel), token);
            var result = new List<FullPaymentModel>();
            foreach (var payment in allPayments)
            {
                var user = await _userRepository.FindOneAsync(x => x.Id == payment.UserId, token);
                var expensesType = await _expensesTypeManager.GetExpensesTypeAsync(payment.ExpensesTypeId, token);
                var PaymentModel = _paymentsManager.CreateFullPaymentModel(user, expensesType, payment);

                result.Add(PaymentModel);
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

        [HttpPost]
        public async Task<ActionResult> CreatePayment([FromBody] CreatePaymentModel model, CancellationToken token)
        {
            var paymentMap = _createPaymentMapper.Map(model);
            var createPayment = await _paymentsManager.CreatePaymentAsync(paymentMap, token);
            var expensesType = await _expensesTypeManager.GetExpensesTypeAsync(model.ExpensesTypeId, token);
            var user = await _userRepository.GetAsync(createPayment.UserId, token);

            var paymentModel = _paymentsManager.CreateFullPaymentModel(user, expensesType, createPayment);

            return Ok(paymentModel);
        }

    }
}
