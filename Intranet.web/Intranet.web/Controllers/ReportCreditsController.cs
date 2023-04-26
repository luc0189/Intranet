using Intranet.web.Data;
using Intranet.web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Intranet.web.Controllers
{
    public class ReportCreditsController: Controller
    {
        private readonly DataContext _dataContext;
        private readonly IConverterHelper _converterHelper;
        public ReportCreditsController(DataContext dataContext, IConverterHelper converterHelper)
        {
            _dataContext = dataContext;
            _converterHelper = converterHelper;
        }

        public IActionResult Index()
        {
            var model = _dataContext.Credits
                .Where(a => a.IsActive == true)
                .Include(s => s.CreditEntities)
                .Include(s => s.Employee);


            return View(model);
        }
    }
}
