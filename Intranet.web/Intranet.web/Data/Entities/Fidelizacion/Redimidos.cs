using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Data.Entities.Fidelizacion
{
    public class Redimidos
    {
        public int Id { get; set; }
        public string Tercero { get; set; }
        public string  UserRegistra { get; set; }
        public string  FechaRegistro { get; set; }
        public Bono Bono { get; set; }
    }
}
