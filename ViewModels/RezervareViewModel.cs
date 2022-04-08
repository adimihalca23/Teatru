using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Teatru.Web.ViewModels
{
    public class RezervareViewModel
    {
        public int ID { get; set; }
        public DateTime Data { get; set; }
        public string? Email { get; set; }    
        [DisplayName("Sceneta")]
        public int? SelectedScenetaID { get; set; }
        public List<SelectListItem> Scenete { get; set; }
        [DisplayName("Loc")]
        [Range(1, 25)]
        public int? SelectedLocID { get; set; }
        public List<SelectListItem> Locuri { get; set; }
    }
}
