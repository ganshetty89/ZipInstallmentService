using Microsoft.AspNetCore.Mvc;
using Zip.InstallmentsService.Model;
using Zip.InstallmentsService.Service.Interface;

namespace Zip.InstallmentsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class InstallmentController : ControllerBase
    {
        private readonly IPaymentPlanService _paymentPlanService;

        public InstallmentController(IPaymentPlanService paymentPlanService)
        {
            _paymentPlanService = paymentPlanService;
        }

        /// <summary>
        /// Submit an input to generate Payment paln.
        /// </summary>
        /// <param name="paymentPlanInput"></param>
        /// <response code ="200">Payment plan is succeesully generated</response>
        /// <remarks>
        /// PaymentPlanInput:
        ///   PurchaseAmount ==> The total amount for which installment plan needs to be generated.
        ///   NoOfInstallments ==> No. of Installments the customer is opting for. Must be greater than 1.
        ///   Frequency ==> Interval in no. of days which the customer needs to pay the installments
        /// </remarks>
        [HttpPost("generatepaymentplan")]
        public async Task<PaymentPlan> GeneratePaymentPlanAsync(PaymentPlanInput paymentPlanInput)
        {
            return await _paymentPlanService.CreatePaymentPlan(paymentPlanInput);
        }
    }
}
