using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Intranet.web.Data;
using Intranet.web.Data.Entities.Compras;
using Intranet.web.Models;
using Intranet.Web.Helpers;
using Intranet.web.Helpers;

namespace Intranet.web.Controllers.Compras
{
    public class NegociationsController : Controller
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private readonly ICombosHelpers _combosHelpers;
        private readonly IConverterHelper _converterHelper;
        public NegociationsController(DataContext context,
             IUserHelper userHelper,
           ICombosHelpers combosHelpers,
            IConverterHelper converterHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _combosHelpers = combosHelpers;
            _converterHelper = converterHelper;

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
            var model = new NegociationViewModel
            {
                DateCreate = DateTime.Today,

                Clasification = _combosHelpers.GetComboClasification(),
                Providercompras = _combosHelpers.GetComboProviderCompras(),
                Mes = _combosHelpers.GetComboMes(),
               
                //Roles = _combosHelpers.GetComboRoles()
            };
            model.Clasification = _combosHelpers.GetComboClasification();
            model.Providercompras = _combosHelpers.GetComboProviderCompras();
            model.Mes = _combosHelpers.GetComboMes();
           
            //model.Roles = _combosHelpers.GetComboRoles();
            return View(model);
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

        //[HttpPost]
        //public async Task<IActionResult> ActivaVerifica(ActivaVerificaVieModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var negociation = new Negociation
        //        {
        //            Count = model.Count,
        //            DateDelivery = model.DateDelivery,
        //            DateModify = DateTime.Now,
        //            DateRegistro = model.DateRegistro,
        //            Detail = model.Detail,
        //            Employee = await _context.Employees.FindAsync(model.EmployeeId),
        //            Id = model.Id,
        //            Size = model.Size,
        //            UserModify = User.Identity.Name,
        //            UserRegistra = model.UserRegistra
        //        };

        //        _context.Endowments.Update(endowment);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction($"{nameof(Details)}/{model.EmployeeId}");
        //        // return RedirectToAction($"Details/{model.SiteId}");
        //    }
        //    return View(model);

        //}

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
