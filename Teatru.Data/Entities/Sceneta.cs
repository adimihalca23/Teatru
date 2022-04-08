

namespace Teatru.Data.Entities
{
    public class Sceneta
    {
        public int ID { get; set; }
        public string? Nume { get; set; }
        public string? Gen { get; set; }
        public string? Durata { get; set; }
        public IList<Actor> Actori { get; set; }
    }
}
