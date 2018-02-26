using IPayment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPayment.BAL.Interfaces
{
    public interface IPaymentBAL
    {
        PaymentModel CreatePayment(PaymentModel payment);
        List<PaymentModel> GetPaymentByAccountNum(string AccountNum);
    }
}
