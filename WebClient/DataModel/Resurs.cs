using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Resurs
    {
        private int id;
        private string naziv;
        private string opis;
        private TipResursa tip;

        public Resurs()
        {

        }

        public Resurs(int id, string naziv, string opis, TipResursa tip)
        {
            this.Id = id;
            this.Naziv = naziv;
            this.Opis = opis;
            this.Tip = tip;
        }

        public int Id { get => id; set => id = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public string Opis { get => opis; set => opis = value; }
        public TipResursa Tip { get => tip; set => tip = value; }
    }
}
