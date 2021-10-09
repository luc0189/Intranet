using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Data.Entities.Fidelizacion
{
    public class Boletas
    {
        public int Id { get; set; }
       
        public Campaña Campaña { get; set; }
        public TercBnet TercBnet { get; set; }
    }
}
