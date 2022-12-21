using System;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Models.Compras
{
    public class EditPagoViewModel : PagoViewModel
    {
        [MaxLength(30)]
        public string UserModify { get; set; }

        public DateTime DateModify { get; set; }
    }
}
