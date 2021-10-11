using Intranet.web.Data.Entities.Fidelizacion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Models.Fidelizacion
{
    public class AddRedimidosViewModel
    {
        public int BonoId { get; set; }
        public int Id { get; set; }

        [Display(Name = "Novedad")]
        [MaxLength(350, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Tercero { get; set; }
        public string UserRegistra { get; set; }
        public string FechaRegistro { get; set; }
        public Bono Bono { get; set; }
    }
}
