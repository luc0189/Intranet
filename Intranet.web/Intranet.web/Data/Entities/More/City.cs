using Intranet.web.Data.Entities.Activos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Data.Entities.More
{
    public class City: Chereda
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
