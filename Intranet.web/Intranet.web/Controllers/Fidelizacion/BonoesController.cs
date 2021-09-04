﻿using System;
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
    public class BonoesController : Controller
    {
        private readonly DataContext _context;

        public BonoesController(DataContext context)
        {
            _context = context;
        }

        // GET: Bonoes
        public IActionResult Index()
        {
            return View(_context.Bonos
              
              .Include(e => e.Redimidos)
              );
        }
  

        // GET: Bonoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bono = await _context.Bonos
                .Include(e=> e.Redimidos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bono == null)
            {
                return NotFound();
            }

            return View(bono);
        }

        // GET: Bonoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bonoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Redimido,Fechacreado,usuariocrea,Valor,Actividad,Usuariocrea")] Bono bono)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bono);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bono);
        }

        // GET: Bonoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bono = await _context.Bonos.FindAsync(id);
            if (bono == null)
            {
                return NotFound();
            }
            return View(bono);
        }

        // POST: Bonoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo,Redimido,Fechacreado,Usuariocrea,Actividad,Valor")] Bono bono)
        {
            if (id != bono.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bono);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BonoExists(bono.Id))
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
            return View(bono);
        }

        // GET: Bonoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bono = await _context.Bonos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bono == null)
            {
                return NotFound();
            }

            return View(bono);
        }

        // POST: Bonoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bono = await _context.Bonos.FindAsync(id);
            _context.Bonos.Remove(bono);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BonoExists(int id)
        {
            return _context.Bonos.Any(e => e.Id == id);
        }
        public async Task<IActionResult> Redime(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bono = await _context.Bonos
                .FirstOrDefaultAsync(m => m.Id == id);
            var redime = new Redimidos();
            if (bono != null)
            {

                redime.Bono = await _context.Bonos
                .FirstOrDefaultAsync(m => m.Id == id);
                redime.UserRegistra = User.Identity.Name;
                redime.FechaRegistro = DateTime.Now.ToString(); ;
                bono.Redimido = true;

            };
            _context.Bonos.Update(bono);
            _context.Redimidos.Add(redime);
            await _context.SaveChangesAsync();
            
            //return RedirectToAction($"Details/{model.NegociacionId}");
            return RedirectToAction(nameof(Index));
        }

    }
}