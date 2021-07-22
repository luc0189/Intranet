using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Data.Entities.Compras
{
    public class Negociation
    {
        public int Id { get; set; }

        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public string DateIn { get; set; }

        [Required (ErrorMessage ="El campo {0} es requerido.")]
        [MaxLength(600)]
        [Display(Name ="Detalle Negociacion")]
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
        public DateTime Datecreate { get; set; }

        [Display(Name = "UserModif")]
        [MaxLength(30)]
        public string UserModify { get; set; }

        public DateTime DateModifica { get; set; }

        [Display(Name = "User Verifica")]
        [MaxLength(30)]
        public string UserVerifica { get; set; }

        [Display(Name = "Fecha Verifica")]
        [MaxLength(30)]
        public string DateVerifica { get; set; }
        [Display(Name = "Fecha Paga")]
        [MaxLength(30)]
        public string DatePaga { get; set; }

        [Display(Name = "User Paga")]
        [MaxLength(30)]
        public string UserPaga { get; set; }

     


        [Display(Name = "Verificado ")]
        public bool Verificar { get; set; }

       
        [Display(Name = "Pago")]
        public bool Pago { get; set; }

        public Clasification Clasification { get; set; }
        public Providercompras Providercompras { get; set; }
        public User User { get; set; }
        public Mes Mes { get; set; }
        public ICollection<Pagos> Pagos { get; set; }
        public ICollection<Verificado> Verificados { get; set; }

    }
}
