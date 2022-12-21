using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Data.Entities.Activos
{
    public class Model : Chereda
    {
        public int Id { get; set; }
        [Display(Name = "Nombre Modelo")]
        public string Name { get; set; }
        public ICollection<Item> Items { get; set; }

    }
}
