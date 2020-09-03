using DataConverters;
using DataModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Konzola = System.Console; 

namespace WebClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Konzola.WriteLine("Dobrodosli u aplikaciju!");

            string URL = "";
            string operation = "";

            List<string> dozvoljeneOperacije = new List<string>() { "GET", "POST", "PATCH", "DELETE" };

            while (true)
            {
                Konzola.Clear();
                Konzola.WriteLine("Unesite URL:");
                // GET resurs/1
                URL = Konzola.ReadLine();

                string[] split = URL.Split(' ','/');
                operation = split[0];


                // Potrebna je provera da li je unos dobro formatiran

                if (!dozvoljeneOperacije.Contains(operation.ToUpper()))
                {
                    Konzola.WriteLine("Uneli ste nepoznatu operaciju. Pokusajte ponovo!");
                    Konzola.ReadLine();
                    continue;
                }

                // Dodati jos provera..

                Request request = new Request() { Verb = operation, Noun = split[1]};

                try
                {
                    request.Query = split[3];
                    request.Fields = split[4];
                }
                catch(Exception e)
                {
                    Trace.TraceInformation(e.Message);
                }

                JSONtoXMLAdapter adapter = new JSONtoXMLAdapter();
                adapter.ConvertJSONtoXML(JsonConvert.SerializeObject(request));

                Konzola.ReadLine();
            }

        }
    }
}
