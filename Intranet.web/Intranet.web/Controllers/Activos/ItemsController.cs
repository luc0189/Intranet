using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Intranet.web.Data;
using Intranet.web.Data.Entities.Activos;
using Intranet.Web.Helpers;
using Intranet.web.Helpers;
using Intranet.web.Models.Activos;
using static Intranet.web.Helpers.ModalHelper;
using Vereyon.Web;

namespace Intranet.web.Controllers.Activos
{
    public class ItemsController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;
        private readonly ICombosHelpers _combosHelpers;
        private readonly IConverterHelper _converterHelper;
        private readonly IImageHelper _imageHelper;
        private readonly IMailHelper _mailHelper;
        private readonly IFlashMessage _flashMessage;

        public ItemsController(DataContext context,
            IUserHelper userHelper,
            ICombosHelpers combosHelpers,
            IConverterHelper converterHelper,
            IImageHelper imageHelper,
            IMailHelper mailHelper,
            IFlashMessage flashMessage)
        {
            _dataContext = context;
            _userHelper = userHelper;
            _combosHelpers = combosHelpers;
            _converterHelper = converterHelper;
            _imageHelper = imageHelper;
            _mailHelper = mailHelper;
            _flashMessage = flashMessage;
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
            return View(await _dataContext.Items.ToListAsync());
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            Item x = null;
            try
            {
                x = await (from r in _dataContext.Items.Include(e => e.Category)
                                  .Include(e => e.Model)
                                  .Include(r => r.Fabric)
                                  .Include(e => e.Provider)
                           where r.Id == id
                           select r).FirstOrDefaultAsync();
                if (x == null)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return View(x);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            var model = new ActivoViewModel
            {
                Dateitemcreate = DateTime.Today,

                Providers = _combosHelpers.GetComboProveedor(),
                Fabrics = _combosHelpers.GetComboFabricante(),
                Models = _combosHelpers.GetComboModel(),
                Categories = _combosHelpers.GetComboCategory(),
               
                //Roles = _combosHelpers.GetComboRoles()
            };
            model.Providers = _combosHelpers.GetComboProveedor();
            model.Fabrics = _combosHelpers.GetComboFabricante();
            model.Models = _combosHelpers.GetComboModel();
            model.Categories = _combosHelpers.GetComboCategory();
           
            //model.Roles = _combosHelpers.GetComboRoles();
            return View(model);
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ActivoViewModel model)
        {
            if (ModelState.IsValid)
            {

                var item = new Item
                {
                    Serial = model.Serial,
                    Nombre = model.Nombre,
                    Datepurchase = model.Datepurchase,
                    UnitValue = model.UnitValue,
                   
                    Coment = model.Coment,
                    Dateitemcreate = DateTime.Today,
                    TimeGarant = model.TimeGarant,
                    Usucreate = User.Identity.Name,

                    //Category = new List<Category>(),
                    //Fabric = new List<Fabric>(),
                    //Model = new List<Model>(),
                    //Provider = new List<Provider>(),


                    Category = await _dataContext.Categories.FindAsync(model.CategoryId),
                    Fabric = await _dataContext.Fabrics.FindAsync(model.FabricId),
                    Model = await _dataContext.Models.FindAsync(model.ModelId),
                    Provider = await _dataContext.Providers.FindAsync(model.ProviderId),
                    //PositionEmployee = await _dataContext.PositionEmployees.FindAsync(model.PositionEmpId)


                };
                _dataContext.Items.Add(item);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));




            }
            _flashMessage.Danger("El activo Existe.");
            model.Providers = _combosHelpers.GetComboProveedor();
            model.Fabrics = _combosHelpers.GetComboFabricante();
            model.Models = _combosHelpers.GetComboModel();
            model.Categories = _combosHelpers.GetComboCategory();
           
            //model.Roles = _combosHelpers.GetComboRoles();
            return View(model);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _dataContext.Items
                .Include(e => e.Fabric)
                .Include(e => e.Category)
                 .Include(e => e.Model)
                .Include(e => e.Provider)
                
              
                .FirstOrDefaultAsync(o => o.Id == id.Value);
            if (item == null)
            {
                return NotFound();
            }

            var view = new EditActivoViewModel
            {

              
                Id = item.Id,
                Nombre = item.Nombre,
                Activo = item.Activo,
                Serial = item.Serial,
                Datepurchase = item.Datepurchase,
                Coment = item.Coment,
                TimeGarant = item.TimeGarant,
                UnitValue = item.UnitValue,
                Usucreate = item.Usucreate,
                Dateitemcreate = item.Dateitemcreate,
               
                FabricId = item.Fabric.Id,
                Fabrics = _combosHelpers.GetComboFabricante(),

                ModelId = item.Model.Id,
                Models = _combosHelpers.GetComboModel(),

                CategoryId = item.Category.Id,
                Categories = _combosHelpers.GetComboCategory(),

                ProviderId = item.Provider.Id,
                Providers = _combosHelpers.GetComboProveedor(),

               
            };

            return View(view);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Serial,Nombre,Datepurchase,UnitValue,Coment,Dateitemcreate,DateMod,TimeGarant,Activo,Usucreate,Usermod")] Item item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dataContext.Update(item);
                    await _dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.Id))
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
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _dataContext.Items
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _dataContext.Items.FindAsync(id);
            _dataContext.Items.Remove(item);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _dataContext.Items.Any(e => e.Id == id);
        }

        [NoDirectAccess]
        public async Task<IActionResult> AddOrEditFabric(int id)
        {

            if (id == 0)
            {
                Fabric fabric =new Fabric { Usucreo = User.Identity.Name };
                if (fabric == null)
                {
                    return NotFound();
                }

                return View(fabric);
            
            }
            else
            {
                Fabric fabric = await _dataContext.Fabrics.FindAsync(id);
                if (fabric == null)
                {
                    return NotFound();
                }

                return View(fabric);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEditFabric(int id, Fabric fabric)
        {
           
            
            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0) //Insert
                    {
                        _dataContext.Add(fabric);
                        await _dataContext.SaveChangesAsync();
                        _flashMessage.Info("Registro creado.");
                    }
                    else //Update
                    {
                        _dataContext.Update(fabric);
                        await _dataContext.SaveChangesAsync();
                        ModelState.AddModelError(string.Empty, "Registro Actualizado");
                    }
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        _flashMessage.Danger("Ya existe una categoría con el mismo nombre.");
                    }
                    else
                    {
                        _flashMessage.Danger(dbUpdateException.InnerException.Message);
                    }
                    return View(fabric);
                }
                catch (Exception exception)
                {
                    _flashMessage.Danger(exception.Message);
                    return View(fabric);
                }
               
                return Json(new { isValid = true, html = ModalHelper.RenderRazorViewToString(this, "Create", _dataContext.Fabrics.ToList()) });

            }

            return Json(new { isValid = false, html = ModalHelper.RenderRazorViewToString(this, "AddOrEditFabric", fabric) });
        }

        [NoDirectAccess]
        public async Task<IActionResult> AddEditModel(int id)
        {

            if (id == 0)
            {
                Model modelo = new Model { Usucreo = User.Identity.Name };
                if (modelo == null)
                {
                    return NotFound();
                }

                return View(modelo);

            }
            else
            {
                Model modelo = await _dataContext.Models.FindAsync(id);
                if (modelo == null)
                {
                    return NotFound();
                }

                return View(modelo);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEditModel(int id, Model modelo)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0) //Insert
                    {
                        _dataContext.Add(modelo);
                        await _dataContext.SaveChangesAsync();
                        _flashMessage.Info("Registro creado.");
                    }
                    else //Update
                    {
                        _dataContext.Update(modelo);
                        await _dataContext.SaveChangesAsync();
                        _flashMessage.Info("Registro actualizado.");
                    }
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        _flashMessage.Danger("Ya existe una categoría con el mismo nombre.");
                    }
                    else
                    {
                        _flashMessage.Danger(dbUpdateException.InnerException.Message);
                    }
                    return View(modelo);
                }
                catch (Exception exception)
                {
                    _flashMessage.Danger(exception.Message);
                    return View(modelo);
                }

                return Json(new { isValid = true, html = ModalHelper.RenderRazorViewToString(this, "Create", _dataContext.Models.ToList()) });

            }

            return Json(new { isValid = false, html = ModalHelper.RenderRazorViewToString(this, "AddEditModel", modelo) });
        }
        [NoDirectAccess]
        public async Task<IActionResult> AddEditCat(int id)
        {

            if (id == 0)
            {
                Category cat = new Category { Usucreo = User.Identity.Name };
                if (cat == null)
                {
                    return NotFound();
                }

                return View(cat);

            }
            else
            {
                Category cat = await _dataContext.Categories.FindAsync(id);
                if (cat == null)
                {
                    return NotFound();
                }

                return View(cat);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEditCat(int id, Category cat)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0) //Insert
                    {
                        _dataContext.Add(cat);
                        await _dataContext.SaveChangesAsync();
                        _flashMessage.Info("Registro creado.");
                    }
                    else //Update
                    {
                        _dataContext.Update(cat);
                        await _dataContext.SaveChangesAsync();
                        _flashMessage.Info("Registro actualizado.");
                    }
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        _flashMessage.Danger("Ya existe una categoría con el mismo nombre.");
                    }
                    else
                    {
                        _flashMessage.Danger(dbUpdateException.InnerException.Message);
                    }
                    return View(cat);
                }
                catch (Exception exception)
                {
                    _flashMessage.Danger(exception.Message);
                    return View(cat);
                }

                return Json(new { isValid = true, html = ModalHelper.RenderRazorViewToString(this, "Create", _dataContext.Categories.ToList()) });

            }

            return Json(new { isValid = false, html = ModalHelper.RenderRazorViewToString(this, "AddEditCat", cat) });
        }

    }
}
