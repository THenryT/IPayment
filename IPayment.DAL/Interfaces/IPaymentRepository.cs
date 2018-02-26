using IPayment.DAL.Models;
using System.Collections.Generic;

namespace IPayment.DAL.Interfaces
{
    public interface IPaymentRepository
    {
        void SavePayment(PaymentModel payment);
        List<PaymentModel> GetPaymentByAccNum(string accNum);
    }
}
