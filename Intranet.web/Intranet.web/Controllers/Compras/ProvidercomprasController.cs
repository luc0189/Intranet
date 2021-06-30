using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Intranet.web.Data;
using Intranet.web.Data.Entities.Compras;

namespace Intranet.web.Controllers.Compras
{
    public class ProvidercomprasController : Controller
    {
        private readonly DataContext _context;

        public ProvidercomprasController(DataContext context)
        {
            _context = context;
        }

        // GET: Providercompras
        public async Task<IActionResult> Index()
        {
            return View(await _context.providercompras.ToListAsync());
        }

        // GET: Providercompras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var providercompras = await _context.providercompras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (providercompras == null)
            {
                return NotFound();
            }

            return View(providercompras);
        }

        // GET: Providercompras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Providercompras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameProvider")] Providercompras providercompras)
        {
            if (ModelState.IsValid)
            {
                _context.Add(providercompras);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(providercompras);
        }

        // GET: Providercompras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var providercompras = await _context.providercompras.FindAsync(id);
            if (providercompras == null)
            {
                return NotFound();
            }
            return View(providercompras);
        }

        // POST: Providercompras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameProvider")] Providercompras providercompras)
        {
            if (id != providercompras.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(providercompras);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProvidercomprasExists(providercompras.Id))
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
            return View(providercompras);
        }

        // GET: Providercompras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var providercompras = await _context.providercompras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (providercompras == null)
            {
                return NotFound();
            }

            return View(providercompras);
        }

        // POST: Providercompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var providercompras = await _context.providercompras.FindAsync(id);
            _context.providercompras.Remove(providercompras);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProvidercomprasExists(int id)
        {
            return _context.providercompras.Any(e => e.Id == id);
        }
    }
}
