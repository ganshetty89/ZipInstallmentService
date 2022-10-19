using Microsoft.AspNetCore.Mvc;
using Zip.InstallmentsService.Model;
using Zip.InstallmentsService.Service.Interface;

namespace Zip.InstallmentsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstallmentController : ControllerBase
    {
        private readonly IPaymentPlanService _paymentPlanService;

        public InstallmentController(IPaymentPlanService paymentPlanService)
        {
            _paymentPlanService = paymentPlanService;
        }

        [HttpPost("getpaymentplan")]
        public async Task<PaymentPlan> GetPaymentPlanAsync(PaymentPlanInput paymentPlanInput)
        {
            return await _paymentPlanService.CreatePaymentPlan(paymentPlanInput);
        }
    }
}
