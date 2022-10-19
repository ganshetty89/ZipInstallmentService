using Microsoft.AspNetCore.Mvc;
using Zip.InstallmentsService.Model;
using Zip.InstallmentsService.Service.Interface;

namespace Zip.InstallmentsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstallmentController : ControllerBase
    {
        private readonly ILogger<InstallmentController> _logger;
        private readonly IPaymentPlanService _paymentPlanService;

        public InstallmentController(IPaymentPlanService paymentPlanService, ILogger<InstallmentController> logger)
        {
            _paymentPlanService = paymentPlanService;
            _logger = logger;
        }

        [HttpPost("getpaymentplan")]
        public async Task<PaymentPlan> GetPaymentPlanAsync(PaymentPlanInput paymentPlanInput)
        {
            return await _paymentPlanService.CreatePaymentPlan(paymentPlanInput);
        }
    }
}
