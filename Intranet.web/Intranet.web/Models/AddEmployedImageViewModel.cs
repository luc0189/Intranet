using Intranet.web.Data.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Models
{
    public class AddEmployedImageViewModel 


    {
        public int Id { get; set; }

        [Display(Name = "Foto")]
        public IFormFile ImageFile { get; set; }
    }
}
