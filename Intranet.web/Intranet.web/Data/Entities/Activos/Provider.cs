using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Data.Entities.Activos
{
    public class Provider : Chereda
    {
        public int Id { get; set; }
        public string Di { get; set; }
        [Display(Name = "Nombre Proveedor")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }
        public string Direccion { get; set; }

        [Display(Name = "Numero Telefonico")]
        public string Phone { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
