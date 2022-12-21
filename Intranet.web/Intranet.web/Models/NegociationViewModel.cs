using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Models
{
    public class NegociationViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public string DateIn { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(300)]
        [Display(Name = "Detalle Negociacion")]
        public string Detalle { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]

        public long ValorNegociacion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]

        public long BaseLiquidacion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(300)]
        [Display(Name = "N Documento")]
        public string Document { get; set; }


        [MaxLength(100)]
        [Display(Name = "Usuario")]
        public string UsuCreate { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public DateTime DateCreate { get; set; }





        //[DisplayFormat(DataFormatString = "{0:(###) ###-####}", ApplyFormatInEditMode = true)]
        //public string Movil { get; set; }

        //aqui los campos que para tigger




        [Required(ErrorMessage = "The Field {0} is mandatory.")]
        [Display(Name = "Clasification")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe Seleccionar una Clasificacion.")]
        public int ClasificationId { get; set; }

        [Required(ErrorMessage = "The Field {0} is mandatory.")]
        [Display(Name = "Provider compras")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un Proveedor.")]
        public int ProvidercomprasId { get; set; }

        [Display(Name = "Fecha Verifica")]
        [MaxLength(30)]
        public string DateVerifica { get; set; }

        [Display(Name = "Fecha Paga")]
        [MaxLength(30)]
        public string DatePaga { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Mes")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe Seleccionar un Mes.")]
        public int MesId { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Sala de Ventas")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una Sala De Ventas.")]
        public int SalaVentaId { get; set; }
        public IEnumerable<SelectListItem> Clasification { get; set; }
        public IEnumerable<SelectListItem> Providercompras { get; set; }

        public IEnumerable<SelectListItem> Mes { get; set; }
        public IEnumerable<SelectListItem> SalaVentas { get; set; }

    }
}
