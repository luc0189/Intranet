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
    public class CajaCompensacionsController : Controller
    {
        private readonly DataContext _context;

        public CajaCompensacionsController(DataContext context)
        {
            _context = context;
        }

        // GET: CajaCompensacions
        public async Task<IActionResult> Index()
        {
            return View(await _context.CajaCompensacions.ToListAsync());
        }

        // GET: CajaCompensacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cajaCompensacion = await _context.CajaCompensacions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cajaCompensacion == null)
            {
                return NotFound();
            }

            return View(cajaCompensacion);
        }

        // GET: CajaCompensacions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CajaCompensacions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] CajaCompensacion cajaCompensacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cajaCompensacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cajaCompensacion);
        }

        // GET: CajaCompensacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cajaCompensacion = await _context.CajaCompensacions.FindAsync(id);
            if (cajaCompensacion == null)
            {
                return NotFound();
            }
            return View(cajaCompensacion);
        }

        // POST: CajaCompensacions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] CajaCompensacion cajaCompensacion)
        {
            if (id != cajaCompensacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cajaCompensacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CajaCompensacionExists(cajaCompensacion.Id))
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
            return View(cajaCompensacion);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cajaCompensacion = await _context.CajaCompensacions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cajaCompensacion == null)
            {
                return NotFound();
            }
            _context.CajaCompensacions.Remove(cajaCompensacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

       

        private bool CajaCompensacionExists(int id)
        {
            return _context.CajaCompensacions.Any(e => e.Id == id);
        }
    }
}
