using Intranet.web.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Models
{
    public class AddPersonContactViewModel 
    {
        public int EmployeeId { get; set; }
        public int Id { get; set; }

        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "Nombre del contacto")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "telefono")]
        [MaxLength(10)]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "Parentesco")]
        [MaxLength(50)]
        public string relationship { get; set; }
        public Employee Employee { get; set; }
        public DateTime DateRegistro { get; set; }

        [MaxLength(30)]
        public string UserRegistra { get; set; }

      
    }
}
