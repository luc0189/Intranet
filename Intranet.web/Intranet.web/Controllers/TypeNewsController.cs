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
    public class TypeNewsController : Controller
    {
        private readonly DataContext _context;

        public TypeNewsController(DataContext context)
        {
            _context = context;
        }

        // GET: TypeNews
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeNews.ToListAsync());
        }

        // GET: TypeNews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeNew = await _context.TypeNews
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeNew == null)
            {
                return NotFound();
            }

            return View(typeNew);
        }

        // GET: TypeNews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeNews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] TypeNew typeNew)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeNew);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeNew);
        }

        // GET: TypeNews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeNew = await _context.TypeNews.FindAsync(id);
            if (typeNew == null)
            {
                return NotFound();
            }
            return View(typeNew);
        }

        // POST: TypeNews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] TypeNew typeNew)
        {
            if (id != typeNew.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeNew);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeNewExists(typeNew.Id))
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
            return View(typeNew);
        }

        // GET: TypeNews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeNew = await _context.TypeNews
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeNew == null)
            {
                return NotFound();
            }

            return View(typeNew);
        }

        // POST: TypeNews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeNew = await _context.TypeNews.FindAsync(id);
            _context.TypeNews.Remove(typeNew);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeNewExists(int id)
        {
            return _context.TypeNews.Any(e => e.Id == id);
        }
    }
}
