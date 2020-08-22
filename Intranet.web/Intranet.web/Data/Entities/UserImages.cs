﻿using System;

namespace Intranet.web.Data.Entities
{
    public class UserImages
    {
        public int Id { get; set; }
        public String ImageUrl { get; set; }
        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl)
                ? null :
                $"https://myleasinglc.azurewebsites.net{ImageUrl.Substring(1)}";
        public Employee Employee { get; set; }
    }
}
