using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Data.Entities
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "Document")]
        [MaxLength(10)]
        public String Document { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "Lugar de expedicion")]
        [MaxLength(50)]
        public String SiteExpedition { get; set; }

        [Display(Name = "First Name")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "Cargo")]
        [MaxLength(50)]
        public String JobTitle { get; set; }

        
        [Display(Name = "Nivel Educativo")]
        [MaxLength(50)]
        public String NivelEducation { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "Lugar de Nacimiento")]
        [MaxLength(50)]
        public String SiteBirth { get; set; }

        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "Tipo RH")]
        [MaxLength(50)]
        public String Rh { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "Carnet ")]
        public bool License { get; set; }
        
        [Display(Name = "Movil")]
        [MaxLength(10)]
        public string Movil { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "ARL")]
        [MaxLength(50)]
        public bool Arl { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
