using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Request
    {
        private string verb;
        private string noun;
        private string query;
        private string fields;

        public Request()
        {

        }

        public Request(string verb, string noun, string query, string fields)
        {
            this.Verb = verb;
            this.Noun = noun;
            this.Query = query;
            this.Fields = fields;
        }

        public string Verb { get => verb; set => verb = value; }
        public string Noun { get => noun; set => noun = value; }
        public string Query { get => query; set => query = value; }
        public string Fields { get => fields; set => fields = value; }
    }
}