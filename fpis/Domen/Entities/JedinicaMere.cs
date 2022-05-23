using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Entities
{
    public class JedinicaMere
    {
        public int SifraJM { get; set; }
        public string NazivJM { get; set; }
        public List<Usluga> Usluge { get; set; }
    }
}
