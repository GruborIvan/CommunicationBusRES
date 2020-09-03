using DataModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml;

namespace DataConverters
{
    public class JSONtoXMLAdapter
    {
        
        public void ConvertJSONtoXML(string JSON_string)
        {
            XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode(JSON_string,"Resurs");
            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
            doc.WriteTo(xmlTextWriter);

            // Dobijen XML
            string xmlString = stringWriter.ToString();
        }

        public string ConvertXMLtoJSON(string XML_string)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(XML_string);
            string jsonString = JsonConvert.SerializeXmlNode(doc);
            return jsonString;
        }

    }
}
