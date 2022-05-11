using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Models
{
    public class CargosViewModels
    {
        public int EmployeeIds { get; set; }
        public int Id { get; set; }

        [Required(ErrorMessage = "The Field {0} is mandatory.")]
        [Display(Name = "Cargo de empleado")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a cargo de empleado.")]
        public int PositionId { get; set; }
        public string UserRegistra { get; set; }
        public string DateRegistro { get; set; }

        public IEnumerable<SelectListItem> PositionEmployeds { get; set; }

    }
}
