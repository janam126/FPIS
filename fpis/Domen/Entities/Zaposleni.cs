using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Entities
{
    public class Zaposleni
    {
        public int ZaposleniID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public List<IzvestajOBrojuDorucaka> Izvestaji { get; set; }
    }
}
