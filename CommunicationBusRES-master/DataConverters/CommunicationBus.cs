namespace DataConverters
{
	public class CommunicationBus
	{
		// Povratna vrednost ove metode je XML reprezentacija klase Response
		public string ForwardToXMLtoDBAdapter(string xmlstring)
		{
			XMLtoDBadapter adapter = new XMLtoDBadapter();
			return adapter.ConvertXMLtoQuery(xmlstring);
		}

	}
}
