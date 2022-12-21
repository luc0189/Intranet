﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Models
{
    public class EditPersonVieModel : AddPersonContactViewModel
    {
        [MaxLength(30)]
        public string UserModify { get; set; }

        public DateTime DateModify { get; set; }
    }
}
