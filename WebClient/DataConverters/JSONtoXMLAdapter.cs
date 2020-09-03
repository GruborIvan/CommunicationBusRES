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
        
        public string ConvertJSONtoXML(string JSON_string)
        {
            Resurs r = new Resurs() { Id = 1, Naziv = "eee", Opis = "fhwaef" };

            string json = new JavaScriptSerializer().Serialize(r);
            Console.WriteLine(json);

            XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode(json,"Resurs");
            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
            doc.WriteTo(xmlTextWriter);
            return stringWriter.ToString();
        }

    }
}
