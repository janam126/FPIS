using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Entities
{
    public class Restoran
    {
        public int RestoranID { get; set; }
        public string NazivRestorana { get; set; }
        public List<IzvestajOBrojuDorucaka> Izvestaji { get; set; }
    }
}
