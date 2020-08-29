using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Data.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "Document")]
        [MaxLength(10)]
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
        [Display(Name = "Cargo")]
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

        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "Tipo RH")]
        [MaxLength(50)]
        public string Rh { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "Carnet ")]
        public bool License { get; set; }

        [Display(Name = "Movil")]
        [MaxLength(10)]
        public string Movil { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "ARL")]

        public bool Arl { get; set; }


        [Display(Name = "Activo")]
        public bool Activo { get; set; }

        [Display(Name = "Fecha retiro")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public string DateRetiro { get; set; }

        [Display(Name = "Fecha Ingreso")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateIngreso { get; set; }
        
        //aqui los campos que para tigger
        [Display(Name = "Fecha registro")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateRegistro { get; set; }
               

        [MaxLength(30)]
        [Required]
        public string UserRegistra { get; set; }

        [MaxLength(30)]
        public string UserModify { get; set; }

        [Display(Name = "Fecha Modifica")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateModify { get; set; }

        public string FullName => $"{FirstName} {LastName}";
        public Area Area { get; set; }
        public Eps Eps { get; set; }
        public PositionEmployee PositionEmployee { get; set; }
        public Pension Pension { get; set; }
        public CajaCompensacion CajaCompensacion { get; set; }
        

        public ICollection<UserImages> UserImages { get; set; }
        public ICollection<Credit> Credits { get; set; }
        public ICollection<Sons> Sons { get; set; }
        public ICollection<Endowment> Endowments { get; set; }
        public ICollection<Exams> Exams { get; set; }
        public ICollection<PersonContact> PersonContacts { get; set; }
        public ICollection<Incapacity> Incapacities { get; set; }
        


    }
}
