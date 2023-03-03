using System;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Data.Entities
{
    public class EmployedImage
    {

        public int Id { get; set; }

        public Employee Employee { get; set; }

        [Display(Name = "Foto")]
        public Guid ImageId { get; set; }

        [Display(Name = "Image")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string ImageUrl { get; set; }

        //TODO: Pending to change to the correct path
        [Display(Name = "Foto")]
        public string ImageFullPath => ImageUrl == ImageUrl
            ? $"http://192.168.1.219:8081/images/no-image-icon.png"
            : $"{ImageUrl}";

    }
}
