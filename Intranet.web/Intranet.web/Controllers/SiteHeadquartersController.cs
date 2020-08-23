using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Intranet.web.Data;
using Intranet.web.Data.Entities;
using Intranet.Web.Helpers;
using Intranet.web.Helpers;
using Intranet.web.Models;
using System.Security.Policy;

namespace Intranet.web.Controllers
{
    public class SiteHeadquartersController : Controller
    {
        private readonly DataContext _datacontext;
        private readonly IUserHelper _userHelper;
        private readonly ICombosHelpers _combosHelpers;
        private readonly IConverterHelper _converterHelper;

        public SiteHeadquartersController(DataContext context,
            IUserHelper userHelper, ICombosHelpers combosHelpers, IConverterHelper converterHelper)
        {
            _datacontext = context;
            _userHelper = userHelper;
            _combosHelpers = combosHelpers;
            _converterHelper = converterHelper;
        }

      
        public IActionResult Index()
        {
            return View(_datacontext.SiteHeadquarters
                .Include(a => a.Areas));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siteHeadquarters = await _datacontext.SiteHeadquarters
                .Include(a=> a.Areas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (siteHeadquarters == null)
            {
                return NotFound();
            }

            return View(siteHeadquarters);
        }

        // GET: SiteHeadquarters/Create
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] SiteHeadquarters siteHeadquarters)
        {
            if (ModelState.IsValid)
            {
                _datacontext.Add(siteHeadquarters);
                await _datacontext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(siteHeadquarters);
        }

        // GET: SiteHeadquarters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siteHeadquarters = await _datacontext.SiteHeadquarters.FindAsync(id);
            if (siteHeadquarters == null)
            {
                return NotFound();
            }
            return View(siteHeadquarters);
        }

        // POST: SiteHeadquarters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] SiteHeadquarters siteHeadquarters)
        {
            if (id != siteHeadquarters.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _datacontext.Update(siteHeadquarters);
                    await _datacontext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiteHeadquartersExists(siteHeadquarters.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(siteHeadquarters);
        }

     
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siteHeadquarters = await _datacontext.SiteHeadquarters
                .Include(s => s.Areas)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (siteHeadquarters == null)
            {
                return NotFound();
            }
            if (siteHeadquarters.Areas.Count != 0  )
            {
                ModelState.AddModelError(string.Empty, "Valide los detalles antes de Borrar");
                return RedirectToAction(nameof(Index));
            }

            _datacontext.SiteHeadquarters.Remove(siteHeadquarters);
            await _datacontext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

       

        private bool SiteHeadquartersExists(int id)
        {
            return _datacontext.SiteHeadquarters.Any(e => e.Id == id);
        }
        public async Task<IActionResult> AddArea(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var site = await _datacontext.SiteHeadquarters.FindAsync(id);
            if (site == null)
            {
                return NotFound();
            }
            var model = new AddAreaViewModel
            {
                SiteId = site.Id,

            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddArea(AddAreaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var sons = await _converterHelper.ToAreaAsync(model, true);
                _datacontext.Areas.Add(sons);
                await _datacontext.SaveChangesAsync();
                return RedirectToAction($"Details/{model.SiteId}");
            }
            return View(model);
        }

        public async Task<IActionResult> EditArea(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var site = await _datacontext.Areas
                .Include(s => s.SiteHeadquarters)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (site == null)
            {
                return NotFound();
            }
           
            return View(_converterHelper.ToAreaViewModel(site));
        }
       
        [HttpPost]
        public async Task<IActionResult> EditArea(AddAreaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var area = await _converterHelper.ToAreaAsync(model, false);
                _datacontext.Areas.Update(area);
                await _datacontext.SaveChangesAsync();
                return RedirectToAction($"{nameof(Details)}/{model.SiteId}");
               // return RedirectToAction($"Details/{model.SiteId}");
            }
            return View(model);
        }
    }
}
