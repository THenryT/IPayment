using IPayment.BAL;
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
    public class UnitTestPaymentBAL
    {
        List<PaymentModel> _payments;
        public UnitTestPaymentBAL()
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
        public void CreatePaymentSuccessReturnNewPayment()
        {
            var payment = new PaymentModel()
            {
                BankName = "CommonWealth",
                Amount = 500.21,
                AccountName = "Yequan Zhang",
                BSB = "123324",
                AccountNum = "12344233"
            };
            var mockRep = new Mock<IPaymentRepository>();
            mockRep.Setup(x => x.SavePayment(payment));

            var paymentBAL = new PaymentBAL(mockRep.Object);
            var result = paymentBAL.CreatePayment(payment);

            Assert.IsNotNull(result.CreatedDate);
        }


        [TestMethod]
        public void GetPaymentsByAccNunSuccessReturnList()
        {
            var AccountNum = "12344233";
            var mockRep = new Mock<IPaymentRepository>();
            mockRep.Setup(x => x.GetPaymentByAccNum(AccountNum)).Returns(_payments.FindAll(i => i.AccountNum == AccountNum));

            var paymentBAL = new PaymentBAL(mockRep.Object);
            var result = paymentBAL.GetPaymentByAccountNum(AccountNum);

            Assert.AreEqual(2, result.Count);
        }
    }
}
