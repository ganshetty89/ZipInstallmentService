using FluentValidation;
using Zip.InstallmentsService.Model;

namespace Zip.InstallmentsService.Validators
{
    public class PaymentPlanInputValidators : AbstractValidator<PaymentPlanInput>
    {
        public PaymentPlanInputValidators()
        {
            PaymentPlanInputValidation();
        }

        private void PaymentPlanInputValidation()
        {
            When(entity => entity != null, () =>
            {
                RuleFor(entity => entity.NoOfInstallments).
                NotNull().WithMessage("NoOfInstallments cannot be null.").
                GreaterThan(1).WithMessage("NoOfInstallments must be greater than 1");

                RuleFor(entity => entity.Frequency).
                NotNull().WithMessage("Frequency cannot be null.").
                GreaterThan(1).WithMessage("Frequency must be greater than 1");

                RuleFor(entity => entity.PurchaseAmount).
                NotNull().WithMessage("PurchaseAmount cannot be null.").
                GreaterThan(0).WithMessage("PurchaseAmount must be greater than 0");
            });
        }
    }
}
