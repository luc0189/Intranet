using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Data.Entities
{
    public class ExamsType
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} Es obrigatorio.")]
        [MaxLength(120)]
        [Display(Name = "Nombre del Examen")]
        public String Name { get; set; }

        public ICollection<Exams> Exams { get; set; }
    }
}
