

namespace Teatru.Data.Entities
{
    public class Actor
    {
        public int ID { get; set; }
        public string? Prenume { get; set; }
        public string? Nume { get; set; }
        public int Varsta { get; set; }
        public DateTime DataNasterii { get; set; }
        public decimal Inaltime { get; set; }     
        public IList<Sceneta> Scenete { get; set; } 
    }
}
