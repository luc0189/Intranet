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
    public class PagosController : Controller
    {
        private readonly DataContext _context;

        public PagosController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Negociation
                .Include(e => e.Providercompras)
                .Include(e => e.Clasification)
                .Include(e => e.Mes)
                .Include(r => r.Verificados)
                .Include(e => e.ProductBonifis)
                .Include(p=> p.Pagoss)
                .ToListAsync());
        }

        public async Task<IActionResult> Searchforeign(string nameForeing)
        {
            if (nameForeing == null)
            {
                return NotFound();
            }
            try
            {
                var Pago = await _context.Negociation
               .Include(s => s.Pagoss)
               .FirstOrDefaultAsync(m => m.Providercompras.NameProvider.Contains(nameForeing));
                if (Pago == null)
                {
                    return NotFound();
                }
                return RedirectToAction($"Details/{Pago.Id}");
            }
            catch (Exception e)
            {

                return RedirectToAction(nameof(Index));
            }

        }

        // GET: Pagos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagos = await _context.Pagos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pagos == null)
            {
                return NotFound();
            }

            return View(pagos);
        }

        // GET: Pagos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pagos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Novedad,DocCobro,DocLegalizacion,ValorPagado,DatePago,Dateregistro,Userregistro,UserModify,DateModify")] Pagos pagos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pagos);
        }

        // GET: Pagos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagos = await _context.Pagos.FindAsync(id);
            if (pagos == null)
            {
                return NotFound();
            }
            return View(pagos);
        }

        // POST: Pagos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Novedad,DocCobro,DocLegalizacion,ValorPagado,DatePago,Dateregistro,Userregistro,UserModify,DateModify")] Pagos pagos)
        {
            if (id != pagos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagosExists(pagos.Id))
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
            return View(pagos);
        }

        // GET: Pagos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagos = await _context.Pagos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pagos == null)
            {
                return NotFound();
            }

            return View(pagos);
        }

        // POST: Pagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pagos = await _context.Pagos.FindAsync(id);
            _context.Pagos.Remove(pagos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagosExists(int id)
        {
            return _context.Pagos.Any(e => e.Id == id);
        }
    }
}
