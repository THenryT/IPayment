using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IPayment.DAL.Models;
using IPayment.BAL.Interfaces;

namespace IPayment.Controllers
{
    [Produces("application/json")]
    [Route("api/Payment")]
    public class PaymentController : Controller
    {
        private readonly IPaymentBAL _paymentBAL;

        public PaymentController(IPaymentBAL paymentBAL)
        {
            _paymentBAL = paymentBAL;
        
        }

        [HttpPost]
        public IActionResult Create([FromBody]PaymentModel paymentRequest)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult GetByAccountNum(string accountNum)
        {
            throw new NotImplementedException();
        }
    }
}