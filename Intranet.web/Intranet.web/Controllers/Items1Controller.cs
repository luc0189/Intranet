using Intranet.web.Data;
using Intranet.web.Data.Entities.Activos;
using Intranet.web.Helpers;
using Intranet.web.Models;
using Intranet.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Intranet.web.Controllers
{
    [Authorize(Roles = "Manager")]
    public class Items1Controller : Controller
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private readonly ICombosHelpers _combosHelpers;
        private readonly IConverterHelper _converterHelper;
        private readonly IImageHelper _imageHelper;


        public Items1Controller(DataContext context,
            IUserHelper userHelper,
            ICombosHelpers combosHelpers,
            IConverterHelper converterHelper,
            IImageHelper imageHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _combosHelpers = combosHelpers;
            _converterHelper = converterHelper;
            _imageHelper = imageHelper;
        }

        // GET: Items1
        public IActionResult Index()
        {
            return View(_context.Items
                .Include(e => e.Model)
                .Include(e => e.Category)
                .Include(e => e.Fabric)
                .Include(e => e.Provider)

               );
        }


        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var item = await _context.Items
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(item);
        //}

        // GET: Items1/Create
        public IActionResult Create()
        {
            var model = new ItemViewModel
            {
               
             

                Modelo = _combosHelpers.GetComboModel(),
                Fabricante = _combosHelpers.GetComboFabricante(),
                Categoria = _combosHelpers.GetComboCategory(),
                Proveedor = _combosHelpers.GetComboProveedor(),
               
                //Roles = _combosHelpers.GetComboRoles()
            };
            model.Modelo = _combosHelpers.GetComboModel();
            model.Fabricante = _combosHelpers.GetComboFabricante();
            model.Categoria = _combosHelpers.GetComboCategory();
            model.Proveedor = _combosHelpers.GetComboProveedor();
           
            //model.Roles = _combosHelpers.GetComboRoles();
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ItemViewModel model)
        {


            if (ModelState.IsValid)
            {

                var item = new Item
                {

                    Serial=model.Seriale,
                    Nombre=model.Nombre,
                    Datepurchase=model.Datepurchase,
                    UnitValue=model.UnitValue,
                    Coment=model.Coment,
                    Usucreate = User.Identity.Name,
                    TimeGarant =model.TimeGarant,
                    Activo=model.Activo,
                    
                    Dateitemcreate = DateTime.Now,
                    Model = await _context.Models.FindAsync(model.ModeloId),
                    Fabric = await _context.Fabrics.FindAsync(model.FabricId),
                    Category = await _context.Categories.FindAsync(model.CategoryId),
                    Provider = await _context.Providers.FindAsync(model.ProviderId),
                 


                };
                _context.Items.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));




            }
            ModelState.AddModelError(string.Empty, "Error: Valide los Datos");
            model.Modelo = _combosHelpers.GetComboModel();
            model.Fabricante = _combosHelpers.GetComboFabricante();
            model.Categoria = _combosHelpers.GetComboCategory();
            model.Proveedor = _combosHelpers.GetComboProveedor();
        
            //model.Roles = _combosHelpers.GetComboRoles();
            return View(model);
        }

        // GET: Items1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = await _context.Items
                .Include(e => e.Model)
                .Include(e => e.Category)
                .Include(e => e.Fabric)
                .Include(e => e.Provider)
                .FirstOrDefaultAsync(o => o.Id == id.Value);
            if (item == null)
            {
                return NotFound();
            }
            var view = new EditItemViewModel
            {

                Seriale = item.Serial,
                Nombre = item.Nombre,
                Datepurchase = item.Datepurchase,
                UnitValue = item.UnitValue,
                Coment = item.Coment,
                Usucreate = item.Usucreate,
                TimeGarant = item.TimeGarant,
                Activo = item.Activo,
                UserModify=item.Usermod,
                DateModify=item.DateMod,
                Dateitemcreate = item.Dateitemcreate,
                ModeloId = item.Model.Id,
                FabricId = item.Fabric.Id,
                CategoryId = item.Category.Id,
                ProviderId = item.Provider.Id,


                
                Modelo = _combosHelpers.GetComboModel(),

                Fabricante = _combosHelpers.GetComboFabricante(),

                Categoria = _combosHelpers.GetComboCategory(),

                Proveedor = _combosHelpers.GetComboProveedor(),

            };
            return View(view);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditItemViewModel vista)
        {
            
            if (ModelState.IsValid)
            {
                var item = await _context.Items
                    .Include(e => e.Model)
                .Include(e => e.Category)
                .Include(e => e.Fabric)
                .Include(e => e.Provider)
                .FirstOrDefaultAsync(o => o.Id == vista.Id);
                if (item != null)
                {
                    item.Serial = vista.Seriale;
                    item.Nombre = vista.Nombre;
                    item.Datepurchase = vista.Datepurchase;
                    item.Coment = vista.Coment;
                    item.TimeGarant = vista.TimeGarant;
                    item.UnitValue = vista.UnitValue;
                    item.Usucreate = vista.Usucreate;
                    item.Usermod = User.Identity.Name;
                    item.DateMod = DateTime.Now;
                    item.Dateitemcreate = vista.Dateitemcreate;
                    item.Activo = vista.Activo;
                   
                    item.Model = await _context.Models.FindAsync(vista.ModeloId);
                    item.Fabric = await _context.Fabrics.FindAsync(vista.FabricId);
                    item.Category = await _context.Categories.FindAsync(vista.CategoryId);
                    item.Provider = await _context.Providers.FindAsync(vista.ProviderId);
                   

                    _context.Items.Update(item);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
              
            }
            return View(vista);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                 .Include(e => e.Model)
                .Include(e => e.Category)
                .Include(e => e.Fabric)
                .Include(e => e.Provider)
                
                .FirstOrDefaultAsync(o => o.Id == id);
            if (item == null)
            {
                return NotFound();
            }
           
               
            

             _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));


        }



        //// GET: Items1/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var item = await _context.Items
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(item);
        //}

        //// POST: Items1/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var item = await _context.Items.FindAsync(id);
        //    _context.Items.Remove(item);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ItemExists(int id)
        //{
        //    return _context.Items.Any(e => e.Id == id);
        //}
    }
}
