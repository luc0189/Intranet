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
    public class NegociationsController : Controller
    {
        private readonly DataContext _context;

        public NegociationsController(DataContext context)
        {
            _context = context;
        }

        // GET: Negociations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Negociation.ToListAsync());
        }

        // GET: Negociations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var negociation = await _context.Negociation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (negociation == null)
            {
                return NotFound();
            }

            return View(negociation);
        }

        // GET: Negociations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Negociations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateIn,Detalle,ValorNegociacion,BaseLiquidacion,Document,UsuCreate,Verificado,Pago")] Negociation negociation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(negociation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(negociation);
        }

        // GET: Negociations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var negociation = await _context.Negociation.FindAsync(id);
            if (negociation == null)
            {
                return NotFound();
            }
            return View(negociation);
        }

        // POST: Negociations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateIn,Detalle,ValorNegociacion,BaseLiquidacion,Document,UsuCreate,Verificado,Pago")] Negociation negociation)
        {
            if (id != negociation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(negociation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NegociationExists(negociation.Id))
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
            return View(negociation);
        }

        // GET: Negociations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var negociation = await _context.Negociation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (negociation == null)
            {
                return NotFound();
            }

            return View(negociation);
        }

        // POST: Negociations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var negociation = await _context.Negociation.FindAsync(id);
            _context.Negociation.Remove(negociation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NegociationExists(int id)
        {
            return _context.Negociation.Any(e => e.Id == id);
        }
    }
}
