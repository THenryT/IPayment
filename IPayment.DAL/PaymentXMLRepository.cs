using IPayment.DAL.Interfaces;
using IPayment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPayment.DAL
{
    public class PaymentXMLRepository : IPaymentRepository
    {
        private IXMLManager _xmlManager;
        public PaymentXMLRepository(IXMLManager xmlManager)
        {
            _xmlManager = xmlManager;
        }

        public void SavePayment(PaymentModel payment)
        {
            throw new NotImplementedException();
        }

        public List<PaymentModel> GetPaymentByAccNum(string accNum)
        {
            throw new NotImplementedException();
        }
    }
}
