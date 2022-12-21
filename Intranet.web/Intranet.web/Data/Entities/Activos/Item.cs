using System;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Data.Entities.Activos
{
    public class Item
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


        public DateTime DateMod { get; set; }

        [Display(Name = "Garantia en Meses")]
        [Required(ErrorMessage = " El Campo {0} es Oblogatorio.")]

        public int TimeGarant { get; set; }

        [Display(Name = "Activo")]
        public bool Activo { get; set; }

        public string Usucreate { get; set; }
        public string Usermod { get; set; }

        public Provider Provider { get; set; }
        public Model Model { get; set; }
        public Category Category { get; set; }
        public Fabric Fabric { get; set; }

    }
}
