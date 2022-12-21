using System;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Models
{
    public class EditHistorialEmpleadoViewModel : AddHistorialEmpleadoViewModel
    {
        [MaxLength(30)]
        public string UserModify { get; set; }

        public DateTime DateModify { get; set; }
    }
}
