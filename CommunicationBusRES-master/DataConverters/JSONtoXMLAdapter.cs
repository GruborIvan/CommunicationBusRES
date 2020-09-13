using Newtonsoft.Json;
using System.IO;
using System.Xml;

namespace DataConverters
{
	public class JSONtoXMLAdapter
	{
		public string ConvertJSONtoXML(string jsonStringRequest)
		{

			XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode(jsonStringRequest, "Resource");
			StringWriter stringWriter = new StringWriter();
			XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
			doc.WriteTo(xmlTextWriter);

			CommunicationBus adapter = new CommunicationBus();

			// Poziva funkciju iz CommunicationBus
			string xmlResponse = adapter.ForwardToXMLtoDBAdapter(stringWriter.ToString());

			// Kad se vrati povratna vrednost, pretvaranje iz XML u JSON oblik...
			XmlDocument document = new XmlDocument();
			document.Load(xmlResponse);
			string jsonStringResponse = JsonConvert.SerializeXmlNode(document);
			return jsonStringResponse;
		}

	}
}
