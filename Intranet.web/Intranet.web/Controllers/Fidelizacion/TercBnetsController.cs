using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Intranet.web.Data;
using Intranet.web.Data.Entities.Fidelizacion;

namespace Intranet.web.Controllers.Fidelizacion
{
    public class TercBnetsController : Controller
    {
        private readonly DataContext _context;

        public TercBnetsController(DataContext context)
        {
            _context = context;
        }

        // GET: TercBnets
        public async Task<IActionResult> Index()
        {
            return View(await _context.TercBnets.ToListAsync());
        }

        // GET: TercBnets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tercBnet = await _context.TercBnets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tercBnet == null)
            {
                return NotFound();
            }

            return View(tercBnet);
        }

        // GET: TercBnets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TercBnets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Documento,Nombre,Nombre2,Apellido1,Apellido2,Telefono,Correo,Usercreo,Datecrea")] TercBnet tercBnet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tercBnet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tercBnet);
        }

        // GET: TercBnets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tercBnet = await _context.TercBnets.FindAsync(id);
            if (tercBnet == null)
            {
                return NotFound();
            }
            return View(tercBnet);
        }

        // POST: TercBnets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Documento,Nombre,Nombre2,Apellido1,Apellido2,Telefono,Correo,Usercreo,Datecrea")] TercBnet tercBnet)
        {
            if (id != tercBnet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tercBnet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TercBnetExists(tercBnet.Id))
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
            return View(tercBnet);
        }

        // GET: TercBnets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tercBnet = await _context.TercBnets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tercBnet == null)
            {
                return NotFound();
            }

            return View(tercBnet);
        }

        // POST: TercBnets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tercBnet = await _context.TercBnets.FindAsync(id);
            _context.TercBnets.Remove(tercBnet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TercBnetExists(int id)
        {
            return _context.TercBnets.Any(e => e.Id == id);
        }
    }
}
