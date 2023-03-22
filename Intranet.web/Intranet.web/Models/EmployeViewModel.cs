﻿using Microsoft.AspNetCore.Http;
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
        [Display(Name = "Documento")]
        public int Document { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "Lugar de expedicion")]
        [MaxLength(50)]
        public string SiteExpedition { get; set; }

        [Display(Name = "Nombres")]
        [MaxLength(50, ErrorMessage = "El campo {0} admite {1} Caracteres Maximo.")]
        [Required(ErrorMessage = "El campo {0} Es Obligatorio.")]
        public string FirstName { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo {0} admite {1} Caracteres Maximo.")]
        [Required(ErrorMessage = "El campo {0} Es Obligatorio.")]
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

        [MaxLength(200, ErrorMessage = "El campo {0} admite {1} Caracteres Maximo.")]
        [Display(Name = "Direccion")]
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
        [DisplayFormat(DataFormatString = "{0:(###) ###-####}", ApplyFormatInEditMode = true)]
        public string Movil { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "ARL")]
        public bool Arl { get; set; }


        [Display(Name = "Activo")]
        public bool Activo { get; set; }

        [Display(Name = "Fecha Cumpleaños")]
       
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




        public IEnumerable<SelectListItem> Areas { get; set; }
        public IEnumerable<SelectListItem> Eps { get; set; }
        public IEnumerable<SelectListItem> Pension { get; set; }
        public IEnumerable<SelectListItem> CajaCompensacion { get; set; }

        //public IEnumerable<SelectListItem> CargosAsgs { get; set; }
        // public IEnumerable<SelectListItem> Incapacitys { get; set; }




    }
}
