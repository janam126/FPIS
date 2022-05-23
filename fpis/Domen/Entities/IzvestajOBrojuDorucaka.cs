using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Entities
{
    public class IzvestajOBrojuDorucaka
    {
        [Key]
        public int RBIzvestaja { get; set; }
        public DateTime DatumOD { get; set; }
        public DateTime DatumDO { get; set; }
        public string Status { get; set; }
        public int UkupanBrojDorucaka { get; set; }
        public Restoran Restoran { get; set; }
        public int RestoranID { get; set; }
        public Zaposleni Zaposleni { get; set; }
        public int ZaposleniID { get; set; }
        public List<StavkaIzvestaja> StavkeIzvestaja { get; set; }
    }
}
