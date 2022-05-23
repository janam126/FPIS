namespace Domen.Entities
{
    public class Usluga
    {
        public int UslugaID { get; set; }
        public string OpisUsluge { get; set; }
        public string NazivUsluge { get; set; }
        public JedinicaMere JedinicaMere { get; set; }
    }
}