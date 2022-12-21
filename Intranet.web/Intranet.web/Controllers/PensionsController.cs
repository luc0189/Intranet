using Intranet.web.Data;
using Intranet.web.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Controllers
{
    public class PensionsController : Controller
    {
        private readonly DataContext _context;

        public PensionsController(DataContext context)
        {
            _context = context;
        }

        // GET: Pensions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pensions.ToListAsync());
        }

        // GET: Pensions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pension = await _context.Pensions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pension == null)
            {
                return NotFound();
            }

            return View(pension);
        }

        // GET: Pensions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pensions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Pension pension)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pension);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pension);
        }

        // GET: Pensions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pension = await _context.Pensions.FindAsync(id);
            if (pension == null)
            {
                return NotFound();
            }
            return View(pension);
        }

        // POST: Pensions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Pension pension)
        {
            if (id != pension.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pension);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PensionExists(pension.Id))
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
            return View(pension);
        }

        // GET: Pensions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pension = await _context.Pensions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pension == null)
            {
                return NotFound();
            }

            return View(pension);
        }

        // POST: Pensions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pension = await _context.Pensions.FindAsync(id);
            _context.Pensions.Remove(pension);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PensionExists(int id)
        {
            return _context.Pensions.Any(e => e.Id == id);
        }
    }
}
