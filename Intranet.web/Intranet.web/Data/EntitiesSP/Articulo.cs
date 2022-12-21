using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Data.EntitiesSP
{
    public class Articulo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [Display(Name = "Nombre del Area")]
        [MaxLength(40)]
        public string Detalle { get; set; }


        //public ICollection<Employee> Employees { get; set; }

    }
}
