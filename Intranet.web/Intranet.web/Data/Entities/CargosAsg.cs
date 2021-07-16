using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Data.Entities
{
    public class CargosAsg
    {
        public int Id { get; set; }

        [Display(Name = "Fecha Cargo Asignado")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public string DateAsg { get; set; }

        public Employee Employee { get; set; }
        public PositionEmployee PositionEmployee { get; set; }

    }
}
