using DataConverters;
using System;
using System.Collections.Generic;
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
            Konzola.WriteLine("Unesite URL:");

            string URL = "";
            string operation = "";

            List<string> dozvoljeneOperacije = new List<string>() { "GET", "POST", "PATCH", "DELETE" };


            JSONtoXMLAdapter adapter = new JSONtoXMLAdapter();
            adapter.ConvertJSONtoXML("eee");



            while (true)
            {
                // GET resurs/1
                URL = Konzola.ReadLine();

                string[] split = URL.Split(' ','/');
                operation = split[0];

                if (!dozvoljeneOperacije.Contains(operation.ToUpper()))
                {
                    Konzola.WriteLine("Uneli ste nepoznatu operaciju. Pokusajte ponovo!");
                    Konzola.ReadLine();
                    continue;
                }

                // Potrebna je provera da li je unos dobro formatiran


                // Razlicite akcije u zavisnosti od toga koja funkcija se poziva...
                switch (operation.ToUpper())
                {
                    case "GET": break;
                    case "POST": break;
                    case "PATCH": break;
                    case "DELETE": break;
                    default:
                        break;
                }

            }

        }
    }
}
