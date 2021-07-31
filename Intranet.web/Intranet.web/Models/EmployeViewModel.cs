using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Models
{
    public class EmployeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "Document")]
        public int Document { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "Lugar de expedicion")]
        [MaxLength(50)]
        public string SiteExpedition { get; set; }

        [Display(Name = "First Name")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "Ocupacion")]
        [MaxLength(50)]
        public string JobTitle { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "Email")]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Nivel Educativo")]
        [MaxLength(50)]
        public string NivelEducation { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "Lugar de Nacimiento")]
        [MaxLength(50)]
        public string SiteBirth { get; set; }

        [MaxLength(200, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "Tipo RH")]
        [MaxLength(50)]
        public string Rh { get; set; }

        [Display(Name = "SEXO")]
        [MaxLength(50)]
        public string Sexo { get; set; }



        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "Carnet ")]
        public bool License { get; set; }

        [Display(Name = "Movil")]
        [MaxLength(10)]
        [DisplayFormat(DataFormatString = "{0:(###) ###-####}",ApplyFormatInEditMode = true)]
        public string Movil { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "ARL")]
        public bool Arl { get; set; }


        [Display(Name = "Activo")]
        public bool Activo { get; set; }

        [Display(Name = "Fecha Cumpleaños")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public string DateCumple { get; set; }

        [Display(Name = "Fecha retiro")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public string DateRetiro { get; set; }

        [Display(Name = "Fecha Ingreso")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public string DateIngreso { get; set; }

        //aqui los campos que para tigger
        [Display(Name = "Sueldo")]
        [MaxLength(80)]
        public int Sueldo { get; set; }


        [Display(Name = "CTA Nomina")]
        public bool CtaNomina { get; set; }


        [Display(Name = "Numero de Cuenta")]
        [MaxLength(80)]
        public string NumeroCtaAhorros { get; set; }


        [MaxLength(30)]
        public string UserCrea { get; set; }

        public DateTime DateRegistro { get; set; }



        [Required(ErrorMessage = "The Field {0} is mandatory.")]
        [Display(Name = "Area")]

        public int AreaId { get; set; }

        [Required(ErrorMessage = "The Field {0} is mandatory.")]
        [Display(Name = "Eps")]

        public int EpsId { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Pension")]
        public int PensionId { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Caja Compensacion")]
        public int CajaCompenId { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Cargo")]
        public int PositionEmpId { get; set; }



        public IEnumerable<SelectListItem> Areas { get; set; }
        public IEnumerable<SelectListItem> Eps { get; set; }
        public IEnumerable<SelectListItem> Pension { get; set; }
        public IEnumerable<SelectListItem> CajaCompensacion { get; set; }
        public IEnumerable<SelectListItem> PositionEmplooyed { get; set; }
        public IEnumerable<SelectListItem> Incapacitys { get; set; }
      

    }
}
