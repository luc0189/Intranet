using Intranet.web.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Models
{
    public class CreditViewModel : Credit
    {
        public int EmployeeIds { get; set; }

        [Required(ErrorMessage = "The Field {0} is mandatory.")]
        [Display(Name = "Entity Credit")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a Entity Credit.")]
        public int EntityId { get; set; }

        public IEnumerable<SelectListItem> Entityes { get; set; }
    }
}
