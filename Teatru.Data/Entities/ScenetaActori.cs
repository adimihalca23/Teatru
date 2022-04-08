

namespace Teatru.Data.Entities
{
    public class ScenetaActori
    {
        public int ActorID { get; set; }
        public Actor Actori { get; set; }
        public int ScenetaID { get; set; }
        public Sceneta Scenete { get; set; }
    }
}
