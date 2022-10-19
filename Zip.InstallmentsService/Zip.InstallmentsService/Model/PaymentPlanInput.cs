namespace Zip.InstallmentsService.Model
{
    public class PaymentPlanInput
    {
        public decimal PurchaseAmount { get; set; }

        public int NoOfInstallments { get; set; }

        public int Frequency { get; set; }
    }
}
