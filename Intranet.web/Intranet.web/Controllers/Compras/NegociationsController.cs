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
using System.Data.SqlClient;


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
         
               var x = await (from r in _context.Negociation
                                   .Include(e => e.Providercompras)
                                   .Include(e => e.Clasification)
                                   .Include(e => e.Mes)
                                   .Include(e => e.Pagoss)
                                   .Include(r => r.Verificados)
                                   .Include(e => e.ProductBonifis)
                                   .Include(e => e.SalaVenta)
                           where r.Pago == false || r.Verificar== false
                          select r).ToListAsync();
                if (x == null)
                {
                    return NotFound();
                }
            
           
            return View(x);
            //return View(await _context.Negociation
            //    .Include(e=> e.Providercompras)
            //    .Include(e=> e.Clasification)
            //    .Include(e=> e.Mes)
            //    .Include(e => e.Pagoss)
            //    .Include(r=> r.Verificados)
            //    .Include(e => e.ProductBonifis)
            //    .Include(e=>e.SalaVenta)
            //    .ToListAsync());
        }
        public async Task<IActionResult> ReportNego()
        {
            return View(await _context.Negociation
                .Include(a=> a.Providercompras)
                .Include(a => a.Clasification)
                .Include(a => a.Mes)
                .Include(a => a.Pagoss)
                .Include(a => a.Verificados)
                .Include(a => a.ProductBonifis)
                .Include(a => a.SalaVenta)
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
                .Include(e=> e.Pagoss)
                .Include(e => e.Clasification)
                .Include(e=> e.Verificados)
                .Include(e=>e.ProductBonifis)
                .Include(e=>e.SalaVenta)
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
                SalaVentas = _combosHelpers.GetComboSalaVentas(),
               
                //Roles = _combosHelpers.GetComboRoles()
            };
            model.Clasification = _combosHelpers.GetComboClasification();
            model.Providercompras = _combosHelpers.GetComboProviderCompras();
            model.Mes = _combosHelpers.GetComboMes();
            model.SalaVentas = _combosHelpers.GetComboSalaVentas();
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
                    Mes = await _context.Mes.FindAsync(model.MesId),
                    SalaVenta=await _context.SalaVentas.FindAsync(model.SalaVentaId)
                    //PositionEmployee = await _dataContext.PositionEmployees.FindAsync(model.PositionEmpId)


                };
                try
                {
                    _context.Negociation.Add(negociacion);
                    await _context.SaveChangesAsync();
                    model.Providercompras = _combosHelpers.GetComboProviderCompras();
                    model.Clasification = _combosHelpers.GetComboClasification();
                    model.Mes = _combosHelpers.GetComboMes();
                    model.SalaVentas = _combosHelpers.GetComboSalaVentas();
                    ModelState.AddModelError(string.Empty, "Registro Correcto");
                }
                catch (Exception e)
                {
                    ViewBag.Message = $"Excepcion no Controlada: {e.Message} mas detalles:{e.InnerException}";
                    return View(model);
                }

                                
              
                return View(model);


            }
            
            model.Providercompras = _combosHelpers.GetComboProviderCompras();
            model.Clasification = _combosHelpers.GetComboClasification();
            model.Mes = _combosHelpers.GetComboMes();
            model.SalaVentas = _combosHelpers.GetComboSalaVentas();
            ModelState.AddModelError(string.Empty, "Registro Fallido: Revise la informacion");
            //model.Roles = _combosHelpers.GetComboRoles();
            return View(model);
        }
        //public Task<IActionResult> Negociacionesvalor()
        //{
        //    List<Negociation> neg = new List<Negociation>();
        //    var sqlnegociacion = from n in neg
        //                         where (n.ValorNegociacion ==410)
        //                         select n;
        //    if (sqlnegociacion == null)
        //    {
        //        return NotFound();
        //    }
        //    foreach (var item in sqlnegociacion)
        //    {
        //        return View(sqlnegociacion);
        //    }


        //    return View(sqlnegociacion);
        //}
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
                .Include(e=> e.SalaVenta)
               
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
                
                Clasification = _combosHelpers.GetComboClasification(),
                ClasificationId = negociation.Clasification.Id,
                SalaVentas =_combosHelpers.GetComboSalaVentas(),
                SalaVentaId=negociation.SalaVenta.Id,
                Providercompras = _combosHelpers.GetComboProviderCompras(),
                ProvidercomprasId = negociation.Providercompras.Id,

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
                    .Include(e=> e.SalaVenta)
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
                    negociation.SalaVenta = await _context.SalaVentas.FindAsync(vista.SalaVentaId);
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
            vista.SalaVentas = _combosHelpers.GetComboSalaVentas();
          
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

    
        //public async Task<IActionResult> AddProductoBon(string Buscar)
        //{
        //    var modelfull = new SearchNegociationViewModel
        //    {
        //        ProviderId = model.ProviderId,
               
        //    };

        //    if (ModelState.IsValid)
        //    {

        //        var negociaciones = await _converterHelper.ToPagoAsync(modelfull, true);
        //        _context.Pagos.Add(pago);
        //        await _context.SaveChangesAsync();
        //        var negociacion = await _context.Negociation.FirstAsync(s => s.Id == model.NegociacionId);
        //        if (negociacion != null)
        //        {

        //            negociacion.Detalle = negociacion.Detalle;
        //            negociacion.Document = negociacion.Document;
        //            negociacion.UsuCreate = negociacion.UsuCreate;
        //            negociacion.Pago = true;
        //            negociacion.UserPaga = User.Identity.Name;
        //            negociacion.DatePaga = DateTime.Now.ToString();

        //        };
        //        _context.Negociation.Update(negociacion);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction($"Details/{model.NegociacionId}");
        //    }
        //    return View(model);
        //}
        public async Task<IActionResult> EditPago(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var pago = await _context.Pagos
                .Include(s => s.Negociation)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (pago == null)
            {
                return NotFound();
            }

            return View(_converterHelper.ToEditPagoViewModel(pago));
        }
        [HttpPost]
        public async Task<IActionResult> EditPago(EditPagoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var modelfull = new Pagos
                {
                    Negociation = await _context.Negociation.FindAsync(model.NegociacionId),
                    ValorPagado = model.ValorPagado,
                   
                    Userregistro=model.Userregistro,
                    DatePago=model.DatePago,
                    Novedad=model.Novedad,
                    Dateregistro=model.Dateregistro,
                    DocCobro=model.DocCobro,
                    DocLegalizacion=model.DocLegalizacion,
                    Id = model.Id,
                    DateModify = DateTime.Now,
                    UserModify = User.Identity.Name

                };

                _context.Pagos.Update(modelfull);
                await _context.SaveChangesAsync();
                return RedirectToAction($"{nameof(Details)}/{model.NegociacionId}");
                // return RedirectToAction($"Details/{model.SiteId}");
            }
     
            return View(model);
        }


        public async Task<IActionResult> AddProductoBon(int? id)
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
            var model = new ProductBonViewModel
            {
                NegociacionId = negociation.Id,
                Userregistro = User.Identity.Name.ToString(),
                Dateregistro= DateTime.Now,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductoBon(ProductBonViewModel model)
        {
            var modelfull = new ProductBonViewModel
            {
                NegociacionId = model.NegociacionId,
                Plu = model.Plu,
                Articulo = model.Articulo,

                Cant = model.Cant,
                ValorUnit = model.ValorUnit,
              
                Dateregistro = DateTime.Today,
                Userregistro = User.Identity.Name.ToString(),


            };

            if (ModelState.IsValid)
            {

                var productobon = await _converterHelper.ToProductBonAsync(modelfull, true);
                _context.ProductBonifi.Add(productobon);
                await _context.SaveChangesAsync();
                ModelState.AddModelError(string.Empty, "Registro Correcto");

                //return RedirectToAction($"Details/{model.NegociacionId}");
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

        // GET: Negociations/Out_focus/{ProductoID}
        public IActionResult Out_focus(string plu)
        {
            ProductSearchResult productSearchResult = new ProductSearchResult();

            using (SqlConnection connection = new SqlConnection("Server=192.168.1.113,7433;Database=supermio;Persist Security Info=True;User Id=l.sanchez;Password=Team0103"))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"select codigo, detalle from articulo where codigo='{plu}'";
                command.CommandType = System.Data.CommandType.Text;

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            productSearchResult.Codigo = reader[0].ToString();
                            productSearchResult.Nombre = reader[1].ToString();
                        }
                    }
                    else
                    {
                        Console.WriteLine("articulo no Existe");
                    }
                    reader.Close();
                }
            }
            return Ok(productSearchResult.Nombre);

        }




        private bool NegociationExists(int id)
        {
            return _context.Negociation.Any(e => e.Id == id);
        }
        public async Task<IActionResult> DeleteProductBon(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productBon = await _context.ProductBonifi
                .Include(pi => pi.Negociation)
                .FirstOrDefaultAsync(pi => pi.Id == id.Value);
            if (productBon == null)
            {
                return NotFound();
            }


            try
            {
                _context.ProductBonifi.Remove(productBon);
                await _context.SaveChangesAsync();
                return RedirectToAction($"{nameof(Details)}/{productBon.Negociation.Id}");
            }
            catch (Exception e)
            {

                ViewBag.Message = $"Se a Generado una excepcion no Controlada: {e.Message}."; ;
            }
            return View();
        }
    }
   

    public class ProductSearchResult
    {
        public string Codigo { get; set; }

        public string Nombre { get; set; }
    }

}
