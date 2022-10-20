using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zip.InstallmentsService.Controllers;
using Zip.InstallmentsService.Model;
using Zip.InstallmentsService.Service.Interface;

namespace Zip.InstallmentsService.Test.Controllers
{
    [TestClass]
    public class InstallmentControllerTest
    {
        private InstallmentController _installmentController;
        private IPaymentPlanService _paymentPlanService;

        [TestInitialize]
        public void Initialize()
        {
            _paymentPlanService = A.Fake<IPaymentPlanService>();
            _installmentController = new InstallmentController(_paymentPlanService);
        }

        [TestMethod]
        public async Task GetPaymentPlanAsync_Success()
        {
            var paymentPlanInput = A.Fake<PaymentPlanInput>();
            var paymentPlan = A.Fake<PaymentPlan>();

            A.CallTo(() => _paymentPlanService.CreatePaymentPlan(paymentPlanInput)).Returns(paymentPlan);

            var result = await _installmentController.GeneratePaymentPlanAsync(paymentPlanInput);

            Assert.AreEqual(paymentPlan, result);
        }
    }
}
