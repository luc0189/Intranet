using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Data.Entities
{
    public class CargosAsg
    {
        public int Id { get; set; }

        [Display(Name = "Fecha Cargo Asignado")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public string DateAsg { get; set; }

        public Employee Employee { get; set; }


    }
}
