using IPayment.DAL;
using IPayment.DAL.Interfaces;
using IPayment.DAL.Models;
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
        public UnitTestPaymentXMLRepository()
        {
           
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
            mockXMLManager.Setup(i => i.GetObjecs<PaymentModel>("", "")).Returns(_payments);
            var paymentXMLRepository = new PaymentXMLRepository(mockXMLManager.Object);

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
         

            var mockXMLManager = new Mock<IXMLManager>();
            mockXMLManager.Setup(i => i.GetObjecs<PaymentModel>("", "")).Returns(_payments);

            var paymentXMLRepository = new PaymentXMLRepository(mockXMLManager.Object);
            var result = paymentXMLRepository.GetPaymentByAccNum(accountNum);

            Assert.AreEqual(2, result.Count);
        }
    }
}
