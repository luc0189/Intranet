using System;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Data.Entities
{
    public class UserImages
    {
        public int Id { get; set; }

        [Display(Name ="Image")]
        public string ImageUrl { get; set; }
        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl)
                ? null :
                $"https://intranetweblcs.azurewebsites.net{ImageUrl.Substring(1)}";
        public Employee Employee { get; set; }
    }
}
