using System;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Models.Activos
{
    public class EditActivoViewModel : ActivoViewModel
    {

        public string Usermod { get; set; }

        public bool Activo { get; set; }
        [Display(Name = "Fecha Modifico")]
        public DateTime DateMod { get; set; }
    }
}
