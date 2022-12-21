using Intranet.web.Data;
using Intranet.web.Data.Entities.Compras;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Controllers.Compras
{
    public class SalaVentasController : Controller
    {
        private readonly DataContext _context;

        public SalaVentasController(DataContext context)
        {
            _context = context;
        }

        // GET: SalaVentas
        public async Task<IActionResult> Index()
        {
            return View(await _context.SalaVentas.ToListAsync());
        }

        // GET: SalaVentas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salaVenta = await _context.SalaVentas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salaVenta == null)
            {
                return NotFound();
            }

            return View(salaVenta);
        }

        // GET: SalaVentas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalaVentas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] SalaVenta salaVenta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salaVenta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salaVenta);
        }

        // GET: SalaVentas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salaVenta = await _context.SalaVentas.FindAsync(id);
            if (salaVenta == null)
            {
                return NotFound();
            }
            return View(salaVenta);
        }

        // POST: SalaVentas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] SalaVenta salaVenta)
        {
            if (id != salaVenta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salaVenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalaVentaExists(salaVenta.Id))
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
            return View(salaVenta);
        }

        // GET: SalaVentas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salaVenta = await _context.SalaVentas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salaVenta == null)
            {
                return NotFound();
            }

            return View(salaVenta);
        }

        // POST: SalaVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salaVenta = await _context.SalaVentas.FindAsync(id);
            _context.SalaVentas.Remove(salaVenta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalaVentaExists(int id)
        {
            return _context.SalaVentas.Any(e => e.Id == id);
        }
    }
}
