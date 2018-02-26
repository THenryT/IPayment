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
            throw new NotImplementedException();
        }

        public List<PaymentModel> GetPaymentByAccountNum(string AccountNum)
        {
            throw new NotImplementedException();
        }
    }
}
