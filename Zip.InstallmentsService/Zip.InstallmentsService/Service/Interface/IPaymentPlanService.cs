using Zip.InstallmentsService.Model;

namespace Zip.InstallmentsService.Service.Interface
{
    public interface IPaymentPlanService
    {
        Task<PaymentPlan> CreatePaymentPlan(PaymentPlanInput paymentPlanInput);
    }
}
