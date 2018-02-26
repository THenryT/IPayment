using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IPayment.DAL.Models
{
    public class PaymentModel
    {
        private DateTime? _createdDate;
        private DateTime? _processedDate;

        [Required]
        public string AccountName { get; set; }

        [Required]
        public string BankName { get; set; }

        [Required]
        [RegularExpression("([0-9]+)")]
        public string BSB { get; set; }

        [Required]
        [RegularExpression("([0-9]+)")]
        public string AccountNum { get; set; }

        [Required]
        public double Amount { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ProcessedDate { get; set; }
    }
}
