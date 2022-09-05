using Intranet.web.Data;
using Intranet.web.Helpers;
using Intranet.Web.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Intranet.web.Controllers.Activos
{
    public class ActivosController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;
        private readonly ICombosHelpers _combosHelpers;
        private readonly IConverterHelper _converterHelper;
        private readonly IImageHelper _imageHelper;
        private readonly IMailHelper _mailHelper;
        private readonly DataContext _context;
        public ActivosController(DataContext context,
            IUserHelper userHelper,
            ICombosHelpers combosHelpers,
            IConverterHelper converterHelper,
            IImageHelper imageHelper,
            IMailHelper mailHelper)
        {
            _dataContext = context;
            _userHelper = userHelper;
            _combosHelpers = combosHelpers;
            _converterHelper = converterHelper;
            _imageHelper = imageHelper;
            _mailHelper = mailHelper;
        }
        public IActionResult Index()
        {

            return View(_dataContext.Items
                
                );
        }
    }
  
}
