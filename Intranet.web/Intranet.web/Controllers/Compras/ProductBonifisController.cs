using Intranet.web.Data;
using Intranet.web.Data.Entities.Compras;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Controllers.Compras
{
    public class ProductBonifisController : Controller
    {
        private readonly DataContext _context;

        public ProductBonifisController(DataContext context)
        {
            _context = context;
        }

        // GET: ProductBonifis
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductBonifi.ToListAsync());
        }

        // GET: ProductBonifis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productBonifi = await _context.ProductBonifi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productBonifi == null)
            {
                return NotFound();
            }

            return View(productBonifi);
        }

        // GET: ProductBonifis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductBonifis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Plu,Articulo,ValorUnit,Cant,Total")] ProductBonifi productBonifi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productBonifi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productBonifi);
        }

        // GET: ProductBonifis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productBonifi = await _context.ProductBonifi.FindAsync(id);
            if (productBonifi == null)
            {
                return NotFound();
            }
            return View(productBonifi);
        }

        // POST: ProductBonifis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Plu,Articulo,ValorUnit,Cant,Total")] ProductBonifi productBonifi)
        {
            if (id != productBonifi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productBonifi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductBonifiExists(productBonifi.Id))
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
            return View(productBonifi);
        }

        // GET: ProductBonifis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productBonifi = await _context.ProductBonifi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productBonifi == null)
            {
                return NotFound();
            }

            return View(productBonifi);
        }

        // POST: ProductBonifis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productBonifi = await _context.ProductBonifi.FindAsync(id);
            _context.ProductBonifi.Remove(productBonifi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductBonifiExists(int id)
        {
            return _context.ProductBonifi.Any(e => e.Id == id);
        }
    }
}
