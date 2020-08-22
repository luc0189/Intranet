using Intranet.web.Data.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Models
{
    public class UserImageViewModel : UserImages
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
    }
}
