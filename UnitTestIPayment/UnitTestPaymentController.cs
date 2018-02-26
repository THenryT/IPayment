using IPayment.BAL.Interfaces;
using IPayment.Controllers;
using IPayment.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestIPayment
{

    [TestClass]
    public class UnitTestPaymentController
    {
        List<PaymentModel> _payments;
        public UnitTestPaymentController()
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
        public void CreatePaymentSuccessReturn200WithPaymentObject()
        {
            var payment = new PaymentModel()
            {
                BankName = "CommonWealth",
                Amount = 500.21,
                AccountName = "Yequan Zhang",
                BSB = "123324",
                AccountNum = "12344233"
            };
            var mockPaymentBAL = new Mock<IPaymentBAL>();
            mockPaymentBAL.Setup(x => x.CreatePayment(payment)).Returns(payment);

            var paymentController = new PaymentController(mockPaymentBAL.Object);
            var response = paymentController.Create(payment) as ObjectResult;

            Assert.AreEqual(response.StatusCode, 200);

        }
        [TestMethod]
        public void GetPaymentsByAcountNumSuccessReturn200withListObject()
        {

            var selectedAccNum = "123344233";
            var mockPaymentBAL = new Mock<IPaymentBAL>();
            mockPaymentBAL.Setup(x => x.GetPaymentByAccountNum(selectedAccNum)).Returns(_payments.FindAll(i => i.AccountNum == selectedAccNum));

            var paymentController = new PaymentController(mockPaymentBAL.Object);
            var response = paymentController.GetByAccountNum(selectedAccNum) as ObjectResult;

            Assert.AreEqual(200, response.StatusCode);
            Assert.IsNotNull(response.Value);
            var payments = response.Value as List<PaymentModel>;
            Assert.AreEqual(1, payments.Count);

        }
    }
}
