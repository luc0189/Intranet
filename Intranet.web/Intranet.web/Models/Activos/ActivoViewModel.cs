using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Models.Activos
{
    public class ActivoViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Serial")]
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [MaxLength(100, ErrorMessage = "Maximo {0} Caracteres.")]
        public string Serial { get; set; }

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

        [Display(Name = "Fecha Creacion")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public DateTime Dateitemcreate { get; set; }




        [Display(Name = "Garantia en Meses")]
        [Required(ErrorMessage = " El Campo {0} es Oblogatorio.")]

        public int TimeGarant { get; set; }


        public string Usucreate { get; set; }


        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        [Display(Name = "Proveedor")]

        public int ProviderId { get; set; }

        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        [Display(Name = "Modelo")]

        public int ModelId { get; set; }

        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        [Display(Name = "Categoria")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        [Display(Name = "Fabricante")]
        public int FabricId { get; set; }



        public IEnumerable<SelectListItem> Providers { get; set; }
        public IEnumerable<SelectListItem> Models { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> Fabrics { get; set; }

    }
}
