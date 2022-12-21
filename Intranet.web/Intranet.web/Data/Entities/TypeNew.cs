using System.Collections.Generic;

namespace Intranet.web.Data.Entities
{
    public class TypeNew
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<Incapacity> Incapacities { get; set; }
    }
}
