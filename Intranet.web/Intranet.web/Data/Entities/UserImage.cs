using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Data.Entities
{
    public class UserImage
    {
        public int Id { get; set; }
        public String ImageUrl { get; set; }
        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl)
                ? null :
                $"https://myleasinglc.azurewebsites.net{ImageUrl.Substring(1)}";
    }
}
