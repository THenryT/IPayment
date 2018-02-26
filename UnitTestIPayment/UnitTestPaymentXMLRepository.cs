using IPayment.DAL;
using IPayment.DAL.Interfaces;
using IPayment.DAL.Models;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestIPayment
{
    [TestClass]
    public class UnitTestPaymentXMLRepository
    {
        private List<PaymentModel> _payments;
        private const string ROOTNAME = "payments";
        private const string ELEMENTNAME = "payment";
        private IOptions<ApplicationSettings> options;
        public UnitTestPaymentXMLRepository()
        {
            options = Options.Create(new ApplicationSettings()
            {
                XMLUrl = "c:\\temp\\paymentList"
            });
            _payments = new List<PaymentModel>()
                {
                    new PaymentModel()
                    {
                        BankName = "CommonWealth",
                        Amount = 500.21,
                        AccountName = "Yequan Zhang",
                        BSB = "123324",
                        AccountNum = "12344233"
                    },
                    new PaymentModel()
                    {
                        BankName = "CommonWealth",
                        Amount = 123.21,
                        AccountName = "Yequan Zhang",
                        BSB = "123324",
                        AccountNum = "12344233"
                    },
                    new PaymentModel()
                    {
                        BankName = "CommonWealth",
                        Amount = 123.21,
                        AccountName = "Ruby Zhao",
                        BSB = "123324",
                        AccountNum = "123344233"
                    }
                };
        }
        [TestMethod]
        public void SavePaymentSuccessWithoutException()
        {
            var payment = new PaymentModel()
            {
                BankName = "CommonWealth",
                Amount = 500.21,
                AccountName = "Yequan Zhang",
                BSB = "123324",
                AccountNum = "12344233"
            };
            var mockXMLManager = new Mock<IXMLManager>();
            mockXMLManager.Setup(i => i.AddObject<PaymentModel>(payment, options.Value.XMLUrl, String.Empty, String.Empty));

            var paymentXMLRepository = new PaymentXMLRepository(options,mockXMLManager.Object);

            try
            {
                paymentXMLRepository.SavePayment(payment);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void GetPaymentByAccNumSuccessReturnList()
        {
            var accountNum = "12344233";
            var query = $"{ROOTNAME}/{ELEMENTNAME}";
            var mockXMLManager = new Mock<IXMLManager>();
            mockXMLManager.Setup(i => i.GetObjecs<PaymentModel>(options.Value.XMLUrl, query)).Returns(_payments);

            var paymentXMLRepository = new PaymentXMLRepository(options, mockXMLManager.Object);
            var result = paymentXMLRepository.GetPaymentByAccNum(accountNum);

            Assert.AreEqual(2, result.Count);
        }
    }
}
