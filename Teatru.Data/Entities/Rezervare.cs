

namespace Teatru.Data.Entities
{
    public class Rezervare
    {
        public int ID { get; set; }
        public DateTime Data { get; set; } 
        public int? ClientID { get; set; } 
        public Client Client { get; set; }
        public int? ScenetaID { get; set; } 
        public Sceneta Sceneta { get; set; }
        public int? LocID { get; set; }
        public Loc Loc { get; set; }
        public IList<Loc> Locuri { get; set; }

    }
}
