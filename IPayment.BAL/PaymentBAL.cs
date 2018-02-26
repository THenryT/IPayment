using IPayment.BAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using IPayment.DAL.Models;
using IPayment.DAL.Interfaces;

namespace IPayment.BAL
{
    public class PaymentBAL : IPaymentBAL
    {
        private IPaymentRepository _paymentRep;
        public PaymentBAL(IPaymentRepository paymentRep)
        {
            _paymentRep = paymentRep;
        }

        public PaymentModel CreatePayment(PaymentModel payment)
        {
            payment.CreatedDate = DateTime.Now;
            _paymentRep.SavePayment(payment);
            return payment;
        }

        public List<PaymentModel> GetPaymentByAccountNum(string AccountNum)
        {
            var result = _paymentRep.GetPaymentByAccNum(AccountNum);
            return result;
        }
    }
}
