using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Entities
{
    public class StavkaIzvestaja
    {
        public int RBStavke { get; set; }
        public DateTime Datum { get; set; }
        public string Dan { get; set; }
        public int BrojDorucaka { get; set; }
        public IzvestajOBrojuDorucaka IzvestajOBrojuDorucaka { get; set; }
        public int IzvestajOBrojuDorucakaID { get; set; }
    }
}
