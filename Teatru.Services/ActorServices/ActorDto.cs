using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teatru.Services.ActorServices
{
    public class ActorDto
    {
        public int ID { get; set; }
        public string? Prenume { get; set; }
        public string? Nume { get; set; }
        public int Varsta { get; set; }
        public DateTime DataNasterii { get; set; }
        public decimal Inaltime { get; set; }
    }
}
