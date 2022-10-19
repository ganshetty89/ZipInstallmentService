using Zip.InstallmentsService.Model;
using Zip.InstallmentsService.Service.Interface;

namespace Zip.InstallmentsService.Service
{
    public class PaymentPlanService : IPaymentPlanService
    {
        private readonly ILogger<PaymentPlanService> _logger;

        public PaymentPlanService(ILogger<PaymentPlanService> logger)
        {
            _logger = logger;
        }

        public async Task<PaymentPlan> CreatePaymentPlan(PaymentPlanInput paymentPlanInput)
        {
            try
            {
                var paymentPlan = new PaymentPlan()
                {
                    Id = Guid.NewGuid(),
                    PurchaseAmount = paymentPlanInput.PurchaseAmount,
                    Installments = (await Task.Run(() => CalculateInstallments(paymentPlanInput))).ToArray()
                };

                return paymentPlan;
            }
            catch (Exception ex)
            {
                var errorMessage = $"{nameof(CreatePaymentPlan)} method failed.";
                _logger.LogError($"{errorMessage}{ex.Message}");
                throw;
            }
        }

        private List<Installment> CalculateInstallments(PaymentPlanInput paymentPlanInput)
        {
            try
            {
                var today = DateTime.UtcNow.Date;
                var installmentAmount = Math.Round(paymentPlanInput.PurchaseAmount / paymentPlanInput.NoOfInstallments,2);
                var installments = new List<Installment>();

                for (int i = 0; i < paymentPlanInput.NoOfInstallments; i++)
                {
                    var daysToAdd = paymentPlanInput.Frequency * i;
                    var installment = new Installment()
                    {
                        Id = Guid.NewGuid(),
                        DueDate = today.AddDays(daysToAdd),
                        Amount = installmentAmount
                    };

                    installments.Add(installment);
                }

                return installments;
            }
            catch (Exception ex)
            {
                var errorMessage = $"{nameof(CalculateInstallments)} method failed.";
                _logger.LogError($"{errorMessage}{ex.Message}");
                throw;
            }
        }
    }
}
