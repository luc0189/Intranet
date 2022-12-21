using System;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Models
{
    public class EditExamViewModel : ExamViewModel
    {
        [MaxLength(30)]
        public string UserModify { get; set; }

        public DateTime DateModify { get; set; }
    }
}
