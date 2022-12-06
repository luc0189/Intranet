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
    public class PositionEmpController : Controller
    {
        private readonly DataContext _context;

        public PositionEmpController(DataContext context)
        {
            _context = context;
        }

        // GET: PositionEmp
        public async Task<IActionResult> Index()
        {
            return View(await _context.PositionEmp.ToListAsync());
        }

        // GET: PositionEmp/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var positionEmployee = await _context.PositionEmp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (positionEmployee == null)
            {
                return NotFound();
            }

            return View(positionEmployee);
        }

        // GET: PositionEmp/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PositionEmp/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Position")] PositionEmp positionEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(positionEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(positionEmployee);
        }

        // GET: PositionEmp/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var positionEmployee = await _context.PositionEmp.FindAsync(id);
            if (positionEmployee == null)
            {
                return NotFound();
            }
            return View(positionEmployee);
        }

        // POST: PositionEmp/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Position")] PositionEmp positionEmployee)
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

        // GET: PositionEmp/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var positionEmployee = await _context.PositionEmp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (positionEmployee == null)
            {
                return NotFound();
            }

            return View(positionEmployee);
        }

        // POST: PositionEmp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var positionEmployee = await _context.PositionEmp.FindAsync(id);
            _context.PositionEmp.Remove(positionEmployee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PositionEmployeeExists(int id)
        {
            return _context.PositionEmp.Any(e => e.Id == id);
        }
    }
}
