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
using Intranet.web.Models.Compras;

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
            return View(await _context.Negociation
                .Include(e=> e.Providercompras)
                .Include(e=> e.Clasification)
                .Include(e=> e.Mes)
                .Include(r=> r.Verificados)
                .ToListAsync());
        }

        // GET: Negociations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var negociation = await _context.Negociation
                .Include(e=> e.Providercompras)
                .Include(e=> e.Pagos)
                .Include(e => e.Clasification)
                .Include(e=> e.Verificados)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NegociationViewModel model)
        {

            if (ModelState.IsValid)
            {

                var negociacion = new Negociation
                {
                    Document = model.Document,
                    DateIn = model.DateIn,
                    Detalle = model.Detalle,
                    ValorNegociacion = model.ValorNegociacion,
                    BaseLiquidacion = model.BaseLiquidacion,
                    Datecreate = DateTime.Today,
                    UsuCreate = User.Identity.Name,
                   
                    Providercompras = await _context.Providercompras.FindAsync(model.ProvidercomprasId),
                    Clasification = await _context.Clasifications.FindAsync(model.ClasificationId),
                    Mes = await _context.Mes.FindAsync(model.MesId)
                 
                    //PositionEmployee = await _dataContext.PositionEmployees.FindAsync(model.PositionEmpId)


                };
                _context.Negociation.Add(negociacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));




            }
            ModelState.AddModelError(string.Empty, "The user Exist");
            model.Providercompras = _combosHelpers.GetComboProviderCompras();
            model.Clasification = _combosHelpers.GetComboClasification();
            model.Mes = _combosHelpers.GetComboMes();
           
            //model.Roles = _combosHelpers.GetComboRoles();
            return View(model);
        }

        // GET: Negociations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var negociation = await _context.Negociation
                .Include(e => e.Providercompras)
                .Include(e => e.Clasification)
                .Include(e => e.Mes)
                .FirstOrDefaultAsync(o => o.Id == id.Value);
            if (negociation == null)
            {
                return NotFound();
            }

            var view = new EditnegociationViewModel
            {

                Document = negociation.Document,
                DateIn = negociation.DateIn,
                Detalle = negociation.Detalle,
                ValorNegociacion = negociation.ValorNegociacion,
                BaseLiquidacion = negociation.BaseLiquidacion,
                DateCreate = negociation.Datecreate,
                UsuCreate = negociation.UsuCreate,
                UserModify=negociation.UserModify,
                DateModifica=negociation.DateModifica,
                ClasificationId = negociation.Clasification.Id,
                Clasification = _combosHelpers.GetComboClasification(),

                ProvidercomprasId = negociation.Providercompras.Id,
                Providercompras = _combosHelpers.GetComboProviderCompras(),

                MesId = negociation.Mes.Id,
                Mes = _combosHelpers.GetComboMes(),

               
                //PositionEmpId = employe.PositionEmployee.Id,

            };
            return View(view);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditnegociationViewModel vista)
        {


            if (ModelState.IsValid)
            {
                var negociation = await _context.Negociation
                    .Include(e => e.Clasification)
                    .Include(e => e.Providercompras)
                    .Include(e => e.Mes)
                    .FirstOrDefaultAsync(o => o.Id == vista.Id);
                if (negociation != null)
                {
                    negociation.DateIn = vista.DateIn;
                    negociation.Detalle = vista.Detalle;
                    negociation.BaseLiquidacion = vista.BaseLiquidacion;
                    negociation.ValorNegociacion = vista.ValorNegociacion;
                    negociation.Document = vista.Document;
                    negociation.UsuCreate = vista.UsuCreate;
                    negociation.Datecreate = vista.DateCreate;
                    negociation.UserModify = User.Identity.Name;
                    negociation.DateModifica = DateTime.Today;

                    negociation.Clasification = await _context.Clasifications.FindAsync(vista.ClasificationId);
                    negociation.Providercompras = await _context.Providercompras.FindAsync(vista.ProvidercomprasId);
                    negociation.Mes = await _context.Mes.FindAsync(vista.MesId);

                    //employe.PositionEmployee = await _dataContext.PositionEmployees.FindAsync(vista.PositionEmpId);

                    _context.Negociation.Update(negociation);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }


            }
            vista.Clasification = _combosHelpers.GetComboClasification();
            vista.Providercompras = _combosHelpers.GetComboProviderCompras();
            vista.Mes = _combosHelpers.GetComboMes();
          
            return View(vista);
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


        public async Task<IActionResult> AddPago(int? id)
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
            var model = new PagoViewModel
            {
                NegociacionId = negociation.Id,
                Userregistro = User.Identity.Name,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPago(PagoViewModel model)
        {
            var modelfull = new PagoViewModel
            {
                NegociacionId = model.NegociacionId,
                Novedad = model.Novedad,
                DocCobro = model.DocCobro,
                
                DocLegalizacion = model.DocLegalizacion,
                ValorPagado = model.ValorPagado,
                DatePago = model.DatePago,
                Dateregistro= DateTime.Today,
                Userregistro= User.Identity.Name,


            };

            if (ModelState.IsValid)
            {

                var pago = await _converterHelper.ToPagoAsync(modelfull, true);
                _context.Pagos.Add(pago);
                await _context.SaveChangesAsync();
                var negociacion = await _context.Negociation.FirstAsync(s => s.Id == model.NegociacionId);
                if (negociacion != null)
                {

                    negociacion.Detalle = negociacion.Detalle;
                    negociacion.Document = negociacion.Document;
                    negociacion.UsuCreate = negociacion.UsuCreate;
                    negociacion.Pago = true;
                    negociacion.UserPaga = User.Identity.Name;
                    negociacion.DatePaga = DateTime.Now.ToString();
                    
                };
                _context.Negociation.Update(negociacion);
                await _context.SaveChangesAsync();
                return RedirectToAction($"Details/{model.NegociacionId}");
            }
            return View(model);
        }
        public async Task<IActionResult> AddCheckVerificar(int? id)
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
            var model = new VerificaViewModel
            {
                NegociacionId = negociation.Id,
               
            };
            return View(model);



            //if (id == null)
            //{
            //    return NotFound();
            //}
            //var negociacion = await _context.Negociation.FirstAsync(s => s.Id == id);
            //if (negociacion != null)
            //{
               
            //    negociacion.Detalle = negociacion.Detalle;
            //    negociacion.Document = negociacion.Document;
            //    negociacion.UsuCreate = negociacion.UsuCreate;
            //    negociacion.Verificado = true;
            //    negociacion.UserVerifica = User.Identity.Name;
            //    negociacion.DateVerifica = DateTime.Now.ToString();
            //};
            //_context.Negociation.Update(negociacion);
            //await _context.SaveChangesAsync();

            //return RedirectToAction($"Details/{id}");
        }

        [HttpPost]
        public async Task<IActionResult> AddCheckVerificar(VerificaViewModel model)
        {
            var modelfull = new VerificaViewModel
            {
                NegociacionId = model.NegociacionId,
                Novedad = model.Novedad,
               
                Dateregistro = DateTime.Today.ToString(),
                UserRegistro = User.Identity.Name,


            };

            if (ModelState.IsValid)
            {

                var verificado = await _converterHelper.ToVerificaAsync(modelfull, true);
                _context.Verificados.Add(verificado);
                await _context.SaveChangesAsync();
                var negociacion = await _context.Negociation.FirstAsync(s => s.Id == model.NegociacionId);
                if (negociacion != null)
                {

                    negociacion.Detalle = negociacion.Detalle;
                    negociacion.Document = negociacion.Document;
                    negociacion.UsuCreate = negociacion.UsuCreate;
                    negociacion.Verificar = true;
                    negociacion.UserVerifica = User.Identity.Name;
                    negociacion.DateVerifica = DateTime.Now.ToString();

                };
                _context.Negociation.Update(negociacion);
                await _context.SaveChangesAsync();
                return RedirectToAction($"Details/{model.NegociacionId}");
            }
            return View(model);
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
