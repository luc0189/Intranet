﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Data.Entities
{
    public class Contract
    {
        public int Id { get; set; }
     
        [Display(Name = "Fecha retiro")]
        [Required]
        [MaxLength(100)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public string DateStart { get; set; } 
        
        
        [Display(Name = "Fecha retiro")]
        [Required]
        [MaxLength(100)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public string DateEnd { get; set; }

        [Display(Name = "Clausulas")]
        [MaxLength(500)]        
        public string Clausulas{ get; set; }

        [Display(Name = "Clausulas")]
        [MaxLength(500)]
        public string Note { get; set; }
        public Employee Employee { get; set; }
    }
}