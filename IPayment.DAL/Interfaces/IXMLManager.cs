using System;
using System.Collections.Generic;
using System.Text;

namespace IPayment.DAL.Interfaces
{
    public interface IXMLManager
    {
        void AddObject<T>(T item, string path, string rootName, string elementName);
        List<T> GetObjecs<T>(string path, string query);
    }
}
