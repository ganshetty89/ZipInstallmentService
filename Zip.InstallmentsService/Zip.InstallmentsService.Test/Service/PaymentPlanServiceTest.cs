using FakeItEasy;
using Microsoft.Extensions.Logging;
using Zip.InstallmentsService.Model;
using Zip.InstallmentsService.Service;
using Zip.InstallmentsService.Service.Interface;

namespace Zip.InstallmentsService.Test.Service
{
    [TestClass]
    public class PaymentPlanServiceTest
    {
        private ILogger<PaymentPlanService> _logger;
        private IPaymentPlanService _paymentPlanService;

        [TestInitialize]
        public void TestInitialization()
        {
            _logger = A.Fake<ILogger<PaymentPlanService>>();
            _paymentPlanService = new PaymentPlanService(_logger);
        }

        [TestMethod]
        public async Task CreatePaymentPlan_Success()
        {
            //arrange
            var paymentPlanInput = new PaymentPlanInput()
            {
                Frequency = 4,
                NoOfInstallments = 4,
                PurchaseAmount = 200
            };

            //act
            var result = await _paymentPlanService.CreatePaymentPlan(paymentPlanInput);

            //assert
            Assert.AreEqual(result.PurchaseAmount, paymentPlanInput.PurchaseAmount);
            Assert.AreEqual(result.Installments[0].Amount, Math.Round(paymentPlanInput.PurchaseAmount / paymentPlanInput.NoOfInstallments, 2));
        }

        [TestMethod]
        public async Task CreatePaymentPlan_Exception()
        {
            //arrange
            var paymentPlanInput = new PaymentPlanInput()
            {
                Frequency = 4,
                NoOfInstallments = 0,
                PurchaseAmount = 200
            };

            //act and assert
            await Assert.ThrowsExceptionAsync<DivideByZeroException>(async () => await _paymentPlanService.CreatePaymentPlan(paymentPlanInput));
        }
    }
}
