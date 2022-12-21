using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Data.Entities
{
    public class Roles
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "Rol")]
        [MaxLength(150)]
        public string Name { get; set; }


    }
}
