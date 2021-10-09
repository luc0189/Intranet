using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Intranet.web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Intranet.web.Controllers.Fidelizacion
{
    public class GenerarBoletaController : Controller
    {
        private readonly DataContext _context;
        public GenerarBoletaController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
               return View(_context.Campañas
               .Include(e => e.Boletas)
               );

            //return View(await _context.Boletas.ToListAsync());
        }


    }
}
