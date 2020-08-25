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
    public class PositionEmployeesController : Controller
    {
        private readonly DataContext _context;

        public PositionEmployeesController(DataContext context)
        {
            _context = context;
        }

        // GET: PositionEmployees
        public async Task<IActionResult> Index()
        {
            return View(await _context.PositionEmployees.ToListAsync());
        }

        // GET: PositionEmployees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var positionEmployee = await _context.PositionEmployees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (positionEmployee == null)
            {
                return NotFound();
            }

            return View(positionEmployee);
        }

        // GET: PositionEmployees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PositionEmployees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Position")] PositionEmployee positionEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(positionEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(positionEmployee);
        }

        // GET: PositionEmployees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var positionEmployee = await _context.PositionEmployees.FindAsync(id);
            if (positionEmployee == null)
            {
                return NotFound();
            }
            return View(positionEmployee);
        }

        // POST: PositionEmployees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Position")] PositionEmployee positionEmployee)
        {
            if (id != positionEmployee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(positionEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PositionEmployeeExists(positionEmployee.Id))
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
            return View(positionEmployee);
        }

        // GET: PositionEmployees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var positionEmployee = await _context.PositionEmployees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (positionEmployee == null)
            {
                return NotFound();
            }

            return View(positionEmployee);
        }

        // POST: PositionEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var positionEmployee = await _context.PositionEmployees.FindAsync(id);
            _context.PositionEmployees.Remove(positionEmployee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PositionEmployeeExists(int id)
        {
            return _context.PositionEmployees.Any(e => e.Id == id);
        }
    }
}
