using IPayment.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace IPayment.DAL.Utility
{
    public class XMLManager : IXMLManager
    {
        public void AddObject<T>(T item, string path, string rootName, string elementName)
        {
            try
            {
                CheckPathAndInitialFile(path, rootName);
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                var root = doc.SelectSingleNode(rootName);
                XmlElement elemnt = doc.CreateElement(string.Empty, elementName, string.Empty);
                root.AppendChild(elemnt);
                Type type = item.GetType();
                List<PropertyInfo> properties = new List<PropertyInfo>(type.GetProperties());
                foreach (var property in properties)
                {
                    if (property.PropertyType != typeof(DateTime?))
                    {
                        XmlElement childElement = doc.CreateElement(string.Empty, property.Name, string.Empty);
                        var value = property.GetValue(item) != null ? property.GetValue(item).ToString() : "";
                        XmlText text = doc.CreateTextNode(value);
                        childElement.AppendChild(text);
                        elemnt.AppendChild(childElement);
                    }
                }
                doc.Save(path);
            }
            catch
            {
                throw;
            }
        }

        public List<T> GetObjecs<T>(string path, string query)
        {
            var result = new List<T>();
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            var nodes = doc.SelectNodes(query);

            foreach (XmlNode node in nodes)
            {
                XmlSerializer ser = new XmlSerializer(typeof(T), new XmlRootAttribute("payment"));
                T nodeObject = (T)ser.Deserialize(new XmlNodeReader(node));
                result.Add(nodeObject);
            }

            return result;
        }


        private void CheckPathAndInitialFile(string path, string rootName)
        {
            try
            {
                var directoryPath = Path.GetDirectoryName(path);
                if (!Directory.Exists(directoryPath) || !File.Exists(path))
                {
                    Directory.CreateDirectory(directoryPath);
                    XmlDocument doc = new XmlDocument();
                    XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                    XmlElement header = doc.DocumentElement;
                    doc.InsertBefore(xmlDeclaration, header);

                    XmlElement root = doc.CreateElement(string.Empty, rootName, string.Empty);
                    doc.AppendChild(root);
                    doc.Save(path);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
