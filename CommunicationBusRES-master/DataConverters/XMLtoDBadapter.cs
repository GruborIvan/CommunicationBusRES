using System;

namespace DataConverters
{
	public class XMLtoDBadapter
	{
		public string ConvertXMLtoQuery(string xmlstring)
		{
			RequestParserXML adapter = new RequestParserXML();
			string SQLquery = adapter.ParseXML(xmlstring);
			Console.WriteLine(SQLquery);


			Repository repository = new Repository();
			// Pozvati funkciju nad repository da izvrsi upit
			// Proslediti SQL upit (string)

			return "";
		}
	}
}
