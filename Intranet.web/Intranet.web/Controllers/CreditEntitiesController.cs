using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Intranet.web.Data;
using Intranet.web.Data.Entities;

namespace Intranet.web.Controllers
{
    public class CreditEntitiesController : Controller
    {
        private readonly DataContext _context;

        public CreditEntitiesController(DataContext context)
        {
            _context = context;
        }

        // GET: CreditEntities
        public async Task<IActionResult> Index()
        {
            return View(await _context.CreditEntities.ToListAsync());
        }

        // GET: CreditEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditEntities = await _context.CreditEntities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (creditEntities == null)
            {
                return NotFound();
            }

            return View(creditEntities);
        }

        // GET: CreditEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CreditEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CreditEntities creditEntities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(creditEntities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(creditEntities);
        }

        // GET: CreditEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditEntities = await _context.CreditEntities.FindAsync(id);
            if (creditEntities == null)
            {
                return NotFound();
            }
            return View(creditEntities);
        }

        // POST: CreditEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CreditEntities creditEntities)
        {
            if (id != creditEntities.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(creditEntities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CreditEntitiesExists(creditEntities.Id))
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
            return View(creditEntities);
        }

        // GET: CreditEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditEntities = await _context.CreditEntities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (creditEntities == null)
            {
                return NotFound();
            }

            return View(creditEntities);
        }

        // POST: CreditEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var creditEntities = await _context.CreditEntities.FindAsync(id);
            _context.CreditEntities.Remove(creditEntities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CreditEntitiesExists(int id)
        {
            return _context.CreditEntities.Any(e => e.Id == id);
        }
    }
}
