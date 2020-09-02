using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Intranet.web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Intranet.web.Controllers
{
    public class ReportExamController : Controller
    {
        private readonly DataContext _dataContext;

        public ReportExamController(
            DataContext dataContext)
        {
           _dataContext = dataContext;
        }
        public IActionResult Index()
        {
            var users = (from u in _dataContext.Exams
                         join t in _dataContext.ExamsTypes
                         select new
                         {
                             //t.Name,
                             //u.StartDate,
                             //u.EndDate,
                             //u.Activo,

                             Name = t.Name,
                             EndDate = u.EndDate,
                             Dato = SqlFunctions.DateDiff("DAY", now, a.DateLowStock) >= 14) <= 1 ? "A" :
                                            grade.Grade.Value >= 3 ? "B" :
                                            grade.Grade.Value >= 2 ? "C" :
                                            grade.Grade.Value != null ? "D" : "-"
                         }).GroupBy(e => e.AgeRange);





            return View(users) ;
        }
    }
}
