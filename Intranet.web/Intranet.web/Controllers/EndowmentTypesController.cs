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
    public class EndowmentTypesController : Controller
    {
        private readonly DataContext _context;

        public EndowmentTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: EndowmentTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.EndowmentsTypes.ToListAsync());
        }

        // GET: EndowmentTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endowmentType = await _context.EndowmentsTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (endowmentType == null)
            {
                return NotFound();
            }

            return View(endowmentType);
        }

        // GET: EndowmentTypes/Create
        public IActionResult Create()
        {
            var endwType = new EndowmentType
            {
                DateRegistro = DateTime.Now
            };
            return View(endwType);
        }

        // POST: EndowmentTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameType,EspirationDate,UserRegistra,DateRegistro")] EndowmentType endowmentType)
        {
            if (ModelState.IsValid)
            {
                var endwType = new EndowmentType
                {
                    Id = endowmentType.Id,
                    DateRegistro = DateTime.Now,
                    EspirationDate = endowmentType.EspirationDate,
                    Endowments = endowmentType.Endowments,
                    NameType = endowmentType.NameType,
                    UserRegistra = User.Identity.Name

                };
                try
                {
                    _context.Add(endwType);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
                catch (Exception e)
                {

                    ModelState.AddModelError(string.Empty, $"Exception: {e.Message}");
                    TempData["msg"] = $"<script>alert('Exception: {e.Message}');</script>";
                }

            }
            return View(endowmentType);
        }

        // GET: EndowmentTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endowmentType = await _context.EndowmentsTypes.FindAsync(id);
            if (endowmentType == null)
            {
                return NotFound();
            }
            return View(endowmentType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameType,EspirationDate,UserRegistra,UserModify,DateRegistro,DateModify")] EndowmentType endowmentType)
        {
            if (id != endowmentType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(endowmentType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EndowmentTypeExists(endowmentType.Id))
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
            return View(endowmentType);
        }

        // GET: EndowmentTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endowmentType = await _context.EndowmentsTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (endowmentType == null)
            {
                return NotFound();
            }

            return View(endowmentType);
        }

        // POST: EndowmentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var endowmentType = await _context.EndowmentsTypes.FindAsync(id);
                _context.EndowmentsTypes.Remove(endowmentType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, $"Exception: {e.Message}");
                TempData["msg"] = $"<script>alert('Exception: {e.Message}');</script>";
            }
            return View();
        }

        private bool EndowmentTypeExists(int id)
        {
            return _context.EndowmentsTypes.Any(e => e.Id == id);
        }
    }
}
