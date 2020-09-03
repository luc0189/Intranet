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
            var query = from u in _dataContext.Exams
                        select new
                        {
                            name = u.Id,
                            imported = (((TimeSpan)(DateTime.Now - u.EndDate)).Days >= 1 ) ? "Vencido" : "no se"
                        };
            return View(_dataContext.Exams
                .Include(s => s.ExamsType)
                .Include(s => s.Employee));
               
        }
    }
}
