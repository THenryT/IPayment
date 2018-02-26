using IPayment.DAL.Interfaces;
using IPayment.DAL.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace IPayment.DAL
{
    public class PaymentXMLRepository : IPaymentRepository
    {
        private const string ROOTNAME = "payments";
        private const string ELEMENTNAME = "payment";
        private IOptions<ApplicationSettings> _applicationSettings;
        private XmlWriterSettings _xmlWriterSetting = new XmlWriterSettings();
        private IXMLManager _xmlManager;
        public PaymentXMLRepository(IOptions<ApplicationSettings> applicationSetting,IXMLManager xmlManager)
        {
            _applicationSettings = applicationSetting;
            _xmlWriterSetting.Indent = true;
            _xmlManager = xmlManager;
        }

        public void SavePayment(PaymentModel payment)
        {
            _xmlManager.AddObject<PaymentModel>(payment, _applicationSettings.Value.XMLUrl, ROOTNAME, ELEMENTNAME);
        }

        public List<PaymentModel> GetPaymentByAccNum(string accNum)
        {
            var selectedList = new List<PaymentModel>();
            var query = $"{ROOTNAME}/{ELEMENTNAME}";
            var result = _xmlManager.GetObjecs<PaymentModel>(_applicationSettings.Value.XMLUrl, query);
            if (result != null)
            {
                selectedList = result.FindAll(i => i.AccountNum == accNum);
            }
            return selectedList;
        }
    }
}
