using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Intranet.web.Data;
using Intranet.web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Intranet.web.Controllers
{
    public class ReportExamController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IConverterHelper _converterHelper;

        public ReportExamController(
            DataContext dataContext,
            IConverterHelper converterHelper)
        {
           _dataContext = dataContext;
           _converterHelper = converterHelper;
        }
        public async Task<IActionResult> Index()
        {
            //var query = from u in _dataContext.Exams
            //            select new
            //            {
            //                name = u.Id,
            //                imported = (((TimeSpan)(DateTime.Now - u.EndDate)).Days >= 1 ) ? "Vencido" : "no se"
            //            };
            var exams = await _dataContext.Exams
                .Include(s => s.Employee)
                .Include(e => e.ExamsType)
                .FirstOrDefaultAsync(s => s.Id == 1);

            var model = _dataContext.Exams
                .Include(s => s.ExamsType)
                .Where(a => a.Activo == true)
                .Include(s => s.Employee);
            

            return View(_converterHelper.ToReportExamViewModel(exams));
               
        }
    }
}
