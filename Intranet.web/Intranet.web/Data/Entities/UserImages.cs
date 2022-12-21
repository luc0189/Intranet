using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Data.Entities
{
    public class UserImages
    {
        public int Id { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl)
                ? $"https://localhost:44370/images/no-image-icon.png"
                : $"https://intranetweblcs.azurewebsites.net{ImageUrl.Substring(1)}";
        // TODO:cambiar la ruta a la del servidor
        public Employee Employee { get; set; }
    }
}
