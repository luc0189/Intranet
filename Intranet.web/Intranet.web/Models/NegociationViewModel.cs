using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Models
{
    public class NegociationViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public string DateIn { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(300)]
        [Display(Name = "Detalle Negociacion")]
        public string Detalle { get; set; }

        public int ValorNegociacion { get; set; }
        public int BaseLiquidacion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(300)]
        [Display(Name = "N Documento")]
        public string Document { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(100)]
        [Display(Name = "Usuario")]
        public string UsuCreate { get; set; }
        public DateTime DateCreate { get; set; }

        [Display(Name = "User Verifica")]
        [MaxLength(30)]
        public string UserVerifica { get; set; }

        [Display(Name = "User Paga")]
        [MaxLength(30)]
        public string UserPaga { get; set; }

        [Display(Name = "Verificado ")]
        public bool Verificado { get; set; }


        [Display(Name = "Pago")]
        public bool Pago { get; set; }
        //[DisplayFormat(DataFormatString = "{0:(###) ###-####}", ApplyFormatInEditMode = true)]
        //public string Movil { get; set; }

        //aqui los campos que para tigger




        [Required(ErrorMessage = "The Field {0} is mandatory.")]
        [Display(Name = "Clasification")]

        public int ClasificationId { get; set; }

        [Required(ErrorMessage = "The Field {0} is mandatory.")]
        [Display(Name = "Provider compras")]

        public int ProvidercomprasId { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Mes")]
        public int MesId { get; set; }

        public IEnumerable<SelectListItem> Clasification { get; set; }
        public IEnumerable<SelectListItem> Providercompras { get; set; }
       
        public IEnumerable<SelectListItem> Mes { get; set; }

    }
}
