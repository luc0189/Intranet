using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Models
{
    public class ItemViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Serial")]
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [MaxLength(100, ErrorMessage = "Maximo {0} Caracteres.")]
        public string Seriale { get; set; }

        [Display(Name = "Nombre Articulo")]
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [MaxLength(100, ErrorMessage = "Maximo {0} Caracteres.")]
        public string Nombre { get; set; }

        [Display(Name = "Fecha de Compra")]
        [Required(ErrorMessage = " El Campo {0} es Oblogatorio.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public string Datepurchase { get; set; }

        [Display(Name = "Valor Unitario")]
        [Required(ErrorMessage = " El Campo {0} es Oblogatorio.")]
        public double UnitValue { get; set; }

        [Display(Name = "Comentarios")]
        [Required(ErrorMessage = " El Campo {0} es Oblogatorio.")]
        [MaxLength(300, ErrorMessage = "Maximo {0} Caracteres.")]
        public string Coment { get; set; }

        
        public DateTime Dateitemcreate { get; set; }

       
      

        [Display(Name = "Garantia en Meses")]
        [Required(ErrorMessage = " El Campo {0} es Oblogatorio.")]
       
        public int TimeGarant { get; set; }

        [Display(Name = "Activo")]
        public bool Activo { get; set; }


        public string Usucreate { get; set; }
      


        [Required(ErrorMessage = "The Field {0} is mandatory.")]
        [Display(Name = "Fabricante")]
        public int FabricId { get; set; }

        [Required(ErrorMessage = "The Field {0} is mandatory.")]
        [Display(Name = "Modelo")]
        public int ModeloId { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Categoria")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Proveedor")]
        public int ProviderId { get; set; }

      


        public IEnumerable<SelectListItem> Fabricante { get; set; }
        public IEnumerable<SelectListItem> Modelo { get; set; }
        public IEnumerable<SelectListItem> Categoria { get; set; }
        public IEnumerable<SelectListItem> Proveedor { get; set; }
       
    }
}
