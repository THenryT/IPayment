using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IPayment.DAL.Models;
using IPayment.BAL.Interfaces;
using Microsoft.Extensions.Logging;
using IPayment.Attributes;

namespace IPayment.Controllers
{
    [Produces("application/json")]
    [Route("api/Payment")]
    [ValidateModel]
    public class PaymentController : Controller
    {
        private readonly IPaymentBAL _paymentBAL;
        private readonly ILogger<PaymentController> _logger;
        public PaymentController(IPaymentBAL paymentBAL,ILogger<PaymentController> logger)
        {
            _paymentBAL = paymentBAL;
            if (null != logger)
            {
                _logger = logger;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody]PaymentModel paymentRequest)
        {
            _logger.LogInformation($"create payment: {paymentRequest}");
            var result = _paymentBAL.CreatePayment(paymentRequest);
            return new OkObjectResult(result);
        }

        [HttpGet]
        public IActionResult GetByAccountNum(string accountNum)
        {
            _logger.LogInformation($"get payments by accountNum: {accountNum}");
            var result = _paymentBAL.GetPaymentByAccountNum(accountNum);
            return new OkObjectResult(result);
        }
    }
}