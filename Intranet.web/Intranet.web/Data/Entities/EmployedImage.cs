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

        //TODO: Pending to change to the correct path
        [Display(Name = "Foto")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://localhost:44370/images/no-image-icon.png"
            : $"https://shopping4.blob.core.windows.net/products/{ImageId}";

    }
}
