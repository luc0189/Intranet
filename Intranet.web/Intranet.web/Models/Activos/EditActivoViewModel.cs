using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Models.Activos
{
    public class EditActivoViewModel :ActivoViewModel
    {
        [Display(Name = "Fecha Modificacion")]
       
        public string DateMod { get; set; }

        public bool Activo { get; set; }
        [Display(Name = "User Modifico")]
        public string Usermod { get; set; }
    }
}
