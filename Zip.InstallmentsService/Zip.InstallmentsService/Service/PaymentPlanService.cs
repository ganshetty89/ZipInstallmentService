using Zip.InstallmentsService.Model;
using Zip.InstallmentsService.Service.Interface;

namespace Zip.InstallmentsService.Service
{
    public class PaymentPlanService : IPaymentPlanService
    {
        public async Task<PaymentPlan> CreatePaymentPlan(PaymentPlanInput paymentPlanInput)
        {
            try
            {
                var paymentPlan = new PaymentPlan()
                {
                    Id = new Guid(),
                    PurchaseAmount = paymentPlanInput.PurchaseAmount,
                    Installments = (await Task.Run(() => CalculateInstallments(paymentPlanInput))).ToArray()
                };

                return paymentPlan;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static List<Installment> CalculateInstallments(PaymentPlanInput paymentPlanInput)
        {
            try
            {
                var today = DateTime.Today;
                var installmentAmount = paymentPlanInput.PurchaseAmount / paymentPlanInput.NoOfInstallments;
                var installments = new List<Installment>();

                for (int i = 0; i < paymentPlanInput.NoOfInstallments; i++)
                {
                    var daysToAdd = paymentPlanInput.Frequency * i;
                    var installment = new Installment()
                    {
                        Id = new Guid(),
                        DueDate = today.AddDays(daysToAdd),
                        Amount = installmentAmount
                    };

                    installments.Add(installment);
                }

                return installments;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
