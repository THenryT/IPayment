using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

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

        [XmlIgnore]
        public DateTime? CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }

        [XmlIgnore]
        public DateTime? ProcessedDate
        {
            get { return _processedDate; }
            set { _processedDate = value; }
        }

        [JsonIgnore]
        public string CreatedDateString
        {
            get
            {
                return _createdDate.HasValue ? XmlConvert.ToString(_createdDate.Value, XmlDateTimeSerializationMode.Unspecified)
                : string.Empty;
            }
            set
            {
                _createdDate = !string.IsNullOrEmpty(value) ? XmlConvert.ToDateTime(value, XmlDateTimeSerializationMode.Unspecified) : (DateTime?)null;
            }
        }

        [JsonIgnore]
        public string ProcessedDateString
        {
            get
            {
                return _processedDate.HasValue ? XmlConvert.ToString(_processedDate.Value, XmlDateTimeSerializationMode.Unspecified)
                : string.Empty;
            }
            set
            {
                _processedDate = !string.IsNullOrEmpty(value) ? XmlConvert.ToDateTime(value, XmlDateTimeSerializationMode.Unspecified) : (DateTime?)null;
            }
        }
    }
}
