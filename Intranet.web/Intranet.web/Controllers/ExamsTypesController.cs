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
    public class ExamsTypesController : Controller
    {
        private readonly DataContext _context;

        public ExamsTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: ExamsTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExamsTypes.ToListAsync());
        }

        // GET: ExamsTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examsType = await _context.ExamsTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (examsType == null)
            {
                return NotFound();
            }

            return View(examsType);
        }

        // GET: ExamsTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExamsTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ExamsType examsType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(examsType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(examsType);
        }

        // GET: ExamsTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examsType = await _context.ExamsTypes.FindAsync(id);
            if (examsType == null)
            {
                return NotFound();
            }
            return View(examsType);
        }

        // POST: ExamsTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ExamsType examsType)
        {
            if (id != examsType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(examsType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamsTypeExists(examsType.Id))
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
            return View(examsType);
        }

        // GET: ExamsTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examsType = await _context.ExamsTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (examsType == null)
            {
                return NotFound();
            }

            return View(examsType);
        }

        // POST: ExamsTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var examsType = await _context.ExamsTypes.FindAsync(id);
            _context.ExamsTypes.Remove(examsType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamsTypeExists(int id)
        {
            return _context.ExamsTypes.Any(e => e.Id == id);
        }
    }
}
