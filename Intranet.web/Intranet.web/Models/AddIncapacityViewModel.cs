using Intranet.web.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Models
{
    public class AddIncapacityViewModel
    {
        public int EmployeeIds { get; set; }
        public int Id { get; set; }

        [Display(Name = "Dias Novedad")]
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        public int CantDay { get; set; }

        [Display(Name = "Fecha Inicio")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Fecha Fin")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Novedad")]
        [MaxLength(350, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Novedad { get; set; }
        public Employee Employee { get; set; }


        [Required(ErrorMessage = "The Field {0} is mandatory.")]
        [Display(Name = "Type News")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a Type  News.")]
        public int TypeId { get; set; }

        public IEnumerable<SelectListItem> TypeNews { get; set; }
        public DateTime DateRegistro { get; set; }

        [MaxLength(30)]
        public string UserRegistra { get; set; }

       
    }
}
