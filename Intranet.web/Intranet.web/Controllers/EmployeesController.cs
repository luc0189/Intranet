using Intranet.web.Data;
using Intranet.web.Data.Entities;
using Intranet.web.Helpers;
using Intranet.web.Models;
using Intranet.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vereyon.Web;
namespace Intranet.web.Controllers
{

    public class EmployeesController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;
        private readonly ICombosHelpers _combosHelpers;
        private readonly IConverterHelper _converterHelper;
        private readonly IImageHelper _imageHelper;
        private readonly IMailHelper _mailHelper;
        private readonly IFlashMessage _flashMessage;

        public EmployeesController(DataContext context,
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
        public async Task<IActionResult> AddImage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _dataContext.Employees.FindAsync(id.Value);
            if (employee == null)
            {
                return NotFound();
            }

            var model = new UserImageViewModel
            {
                Id = employee.Id
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddImage(UserImageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if (model.ImageFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(model.ImageFile);
                }

                var userImage = new UserImages
                {
                    ImageUrl = path,
                    Employee = await _dataContext.Employees.FindAsync(model.Id)
                };

                _dataContext.UserImages.Add(userImage);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction($"{nameof(Details)}/{model.Id}");
            }

            return View(model);
        }

        public IActionResult Index()
        {

            return View(_dataContext.Employees
                .Include(e => e.Sons)
                .Include(e => e.Area)

                .ThenInclude(s => s.SiteHeadquarters)
                .Include(e => e.PersonContacts)
                .Include(e => e.Credits)
                .Include(e => e.Exams)
                .Include(e => e.CajaCompensacion)
                .Include(e => e.Incapacities)
                .Include(e => e.Endowments)
                .Include(e => e.Contracts)
                .Include(e => e.CargosAsgs)

                .ThenInclude(e => e.PositionEmployee)
                .Include(e => e.UserImages)
                );
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var employee = await _dataContext.Employees
            //    .Include(e => e.Sons)
            //    .Include(e => e.Area)
            //    .Include(e => e.Eps)
            //    .Include(e => e.Pension)
            //    .Include(e => e.CajaCompensacion)
            //    .Include(e => e.PersonContacts)
            //    .Include(i => i.UserImages)
            //    .Include(e => e.Incapacities)
            //    .ThenInclude(e => e.TypeNew)
            //    .Include(e => e.Contracts)
            //    .Include(e => e.CargosAsgs)
            //    .Include(e => e.Credits)
            //    .ThenInclude(c => c.CreditEntities)
            //    .Include(e => e.Exams)
            //    .ThenInclude(t => t.ExamsType)
            //    .Include(e => e.Endowments)
            //    .ThenInclude(c => c.EndowmentType)
            //    .FirstOrDefaultAsync(e => e.Id == id);
            Employee x = null;
            try
            {
                x = await (from r in _dataContext.Employees.Include(e => e.Sons)
                                  .Include(e => e.Area)
                                  .Include(r=> r.HistorialEmpleados)
                                  .Include(e => e.Eps)
                                  .Include(e => e.Pension)
                                  .Include(e => e.CajaCompensacion)
                                  .Include(e => e.PersonContacts)
                                  .Include(i => i.UserImages)
                                  .Include(e => e.Incapacities)
                                  .ThenInclude(e => e.TypeNew)
                                  .Include(e => e.Contracts)
                                  .Include(e => e.CargosAsgs)
                                  .ThenInclude(e=>e.PositionEmployee)
                                  .Include(e => e.Credits)
                                  .ThenInclude(c => c.CreditEntities)
                                  .Include(e => e.Exams)
                                  .ThenInclude(t => t.ExamsType)
                                  .Include(e => e.Endowments)
                                  .ThenInclude(c => c.EndowmentType)
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


        public IActionResult Create()
        {
            var model = new EmployeViewModel
            {
                DateRegistro = DateTime.Today,

                Areas = _combosHelpers.GetComboAreas(),
                Eps = _combosHelpers.GetComboEps(),
                Pension = _combosHelpers.GetComboPension(),
                CajaCompensacion = _combosHelpers.GetComboCajaCompensacion(),
                PositionEmplooyed = _combosHelpers.GetComboPositionEmploye(),
                //Roles = _combosHelpers.GetComboRoles()
            };
            model.Areas = _combosHelpers.GetComboAreas();
            model.Eps = _combosHelpers.GetComboEps();
            model.Pension = _combosHelpers.GetComboPension();
            model.CajaCompensacion = _combosHelpers.GetComboCajaCompensacion();
            model.PositionEmplooyed = _combosHelpers.GetComboPositionEmploye();
            //model.Roles = _combosHelpers.GetComboRoles();
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeViewModel model)
        {


            if (ModelState.IsValid)
            {

                var employe = new Employee
                {
                    Document = model.Document,
                    SiteExpedition = model.SiteExpedition,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Activo = model.Activo,
                    Address = model.Address,
                    DateIngreso = model.DateIngreso,
                    DateRegistro = DateTime.Today,
                    DateRetiro = model.DateRetiro,
                    Email = model.Email,
                    JobTitle = model.JobTitle,
                    License = model.License,
                    Movil = model.Movil,
                    NivelEducation = model.NivelEducation,
                    Rh = model.Rh,
                    SiteBirth = model.SiteBirth,
                    Arl = model.Arl,
                    UserRegistra = User.Identity.Name,
                    DateCumple = model.DateCumple,
                    Credits = new List<Credit>(),
                    Sons = new List<Sons>(),
                    Endowments = new List<Endowment>(),
                    Exams = new List<Exams>(),
                    PersonContacts = new List<PersonContact>(),
                    Incapacities = new List<Incapacity>(),
                    UserImages = new List<UserImages>(),
                    Sexo = model.Sexo,
                    Sueldo = model.Sueldo,
                    Area = await _dataContext.Areas.FindAsync(model.AreaId),
                    Eps = await _dataContext.Eps.FindAsync(model.EpsId),
                    Pension = await _dataContext.Pensions.FindAsync(model.PensionId),
                    CajaCompensacion = await _dataContext.CajaCompensacions.FindAsync(model.CajaCompenId),
                    //PositionEmployee = await _dataContext.PositionEmployees.FindAsync(model.PositionEmpId)


                };
                _dataContext.Employees.Add(employe);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));




            }
            ModelState.AddModelError(string.Empty, "The user Exist");
            model.Areas = _combosHelpers.GetComboAreas();
            model.Eps = _combosHelpers.GetComboEps();
            model.Pension = _combosHelpers.GetComboPension();
            model.CajaCompensacion = _combosHelpers.GetComboCajaCompensacion();
            model.PositionEmplooyed = _combosHelpers.GetComboPositionEmploye();
            //model.Roles = _combosHelpers.GetComboRoles();
            return View(model);
        }

        //private async Task<User> CreateUserAsync(AddUserViewModel model)
        //{
        //    var user = new User
        //    {
        //        Document = model.Document,
        //        SiteExpedition = model.SiteExpedition,
        //        FirstName = model.FirstName,
        //        LastName = model.LastName,
        //        Email = model.Username,
        //        JobTitle = model.JobTitle,
        //        SiteBirth = model.SiteBirth,
        //        Address = model.Address,
        //        Rh = model.Rh,
        //        License = model.License,
        //        Movil = model.Movil,
        //        Arl = model.Arl,
        //        Activo=model.Activo,
        //        DateRetiro=model.DateRetiro,
        //        NivelEducation=model.NivelEducation,
        //        UserName=model.Username

        //    };
        //    var result = await _userHelper.AddUserAsync(user, model.Password);
        //    if (result.Succeeded)
        //    {


        //        user = await _userHelper.GetUserByEmailAsync(model.Username);
        //        await _userHelper.AddUserToRoleAsync(user, "Employe");
        //        return user;
        //    }
        //    return null;
        //}
        //
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employe = await _dataContext.Employees
                .Include(e => e.Sons)
              
                .Include(e => e.Area)
             
                .ThenInclude(s => s.SiteHeadquarters)
                .Include(e => e.PersonContacts)
                .Include(e => e.Credits)
                 .Include(e => e.Pension)
                .Include(e => e.Eps)
                
                .Include(e => e.Exams)
                .Include(e => e.CajaCompensacion)
                .Include(e => e.Endowments)
                .FirstOrDefaultAsync(o => o.Id == id.Value);
            if (employe == null)
            {
                return NotFound();
            }

            var view = new EditEmployedViewModel
            {

                Address = employe.Address,
                Document = employe.Document,
                FirstName = employe.FirstName,
                Id = employe.Id,
                LastName = employe.LastName,
                Activo = employe.Activo,
                Arl = employe.Arl,
                DateRetiro = employe.DateRetiro,
                JobTitle = employe.JobTitle,
                License = employe.License,
                Movil = employe.Movil,
                NivelEducation = employe.NivelEducation,
                Rh = employe.Rh,
                SiteBirth = employe.SiteBirth,
                SiteExpedition = employe.SiteExpedition,
                DateIngreso = employe.DateIngreso,
                Email = employe.Email,
                DateCumple = employe.DateCumple,
                UserCrea = employe.UserRegistra,
                DateModify = employe.DateModify,
                UserModify = employe.UserModify,
                DateRegistro = employe.DateRegistro,
                Sexo=employe.Sexo,
                //PositionEmpId = employe.positionEmployees.Id,
                PositionEmplooyed = _combosHelpers.GetComboPositionEmploye(),
                
                PensionId = employe.Pension.Id,
                Pension = _combosHelpers.GetComboPension(),

                EpsId = employe.Eps.Id,
                Eps = _combosHelpers.GetComboEps(),

                CajaCompenId = employe.CajaCompensacion.Id,
                CajaCompensacion = _combosHelpers.GetComboCajaCompensacion(),

                AreaId = employe.Area.Id,
                Areas = _combosHelpers.GetComboAreas()
            };

            return View(view);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EditEmployedViewModel vista)
        {

            if (ModelState.IsValid)
            {
                var employe = await _dataContext.Employees
                    .Include(e => e.Incapacities)
                    .Include(e => e.Sons)
                    .Include(e => e.Area)
                    .ThenInclude(s => s.SiteHeadquarters)
                    .Include(e => e.PersonContacts)
                    .Include(e => e.Credits)
                    .Include(e => e.Exams)
                    .Include(e => e.CajaCompensacion)
                    .Include(e => e.Endowments)
                    .FirstOrDefaultAsync(o => o.Id == vista.Id);
                if (employe != null)
                {
                    employe.Address = vista.Address;
                    employe.Document = vista.Document;
                    employe.FirstName = vista.FirstName;
                    employe.LastName = vista.LastName;
                    employe.Activo = vista.Activo;
                    employe.Arl = vista.Arl;
                    employe.DateRetiro = vista.DateRetiro;
                    employe.JobTitle = vista.JobTitle;
                    employe.License = vista.License;
                    employe.Movil = vista.Movil;
                    employe.NivelEducation = vista.NivelEducation;
                    employe.Rh = vista.Rh;
                    employe.SiteBirth = vista.SiteBirth;
                    employe.SiteExpedition = vista.SiteExpedition;
                    employe.DateIngreso = vista.DateIngreso;
                    employe.UserRegistra = vista.UserCrea;
                    employe.DateRegistro = vista.DateRegistro;
                    employe.Email = vista.Email;
                    employe.DateModify = DateTime.Today;
                    employe.UserModify = User.Identity.Name;
                    employe.Area = await _dataContext.Areas.FindAsync(vista.AreaId);
                    employe.Eps = await _dataContext.Eps.FindAsync(vista.EpsId);
                    employe.Pension = await _dataContext.Pensions.FindAsync(vista.PensionId);
                    employe.CajaCompensacion = await _dataContext.CajaCompensacions.FindAsync(vista.CajaCompenId);
                    //employe.PositionEmployee = await _dataContext.PositionEmployees.FindAsync(vista.PositionEmpId);

                    _dataContext.Employees.Update(employe);
                    await _dataContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }


            }

            vista.Areas = _combosHelpers.GetComboAreas();
            vista.Eps = _combosHelpers.GetComboEps();
            vista.Pension = _combosHelpers.GetComboPension();
            vista.CajaCompensacion = _combosHelpers.GetComboCajaCompensacion();
            vista.PositionEmplooyed = _combosHelpers.GetComboPositionEmploye();
            //vista.Roles = _combosHelpers.GetComboRoles();

            return View(vista);
        }
        //TODO: para borrar todo puedo utilizar la opcion 59-par19 delete... 21:10
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _dataContext.Employees
                .Include(e => e.PersonContacts)
                .Include(e => e.Sons)
                .Include(e => e.UserImages)
                .Include(e => e.Endowments)
                .Include(e => e.Credits)
                .Include(e => e.Incapacities)

                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            if (employee.PersonContacts.Count != 0 ||
                employee.Sons.Count != 0 ||
                employee.UserImages.Count != 0 ||
                employee.Endowments.Count != 0 ||
                employee.Credits.Count != 0 ||
                employee.Incapacities.Count != 0)
            {
                _flashMessage.Danger("Valide los detalles antes de Borrar");
               
                return RedirectToAction(nameof(Index));
            }

            _dataContext.Employees.Remove(employee);
            await _dataContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));


        }


        private bool EmployeeExists(int id)
        {
            return _dataContext.Employees.Any(e => e.Id == id);
        }
        public async Task<IActionResult> AddExam(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employe = await _dataContext.Employees.FindAsync(id);
            if (employe == null)
            {
                return NotFound();
            }
            var model = new ExamViewModel
            {
                EmployeeId = employe.Id,
                ExamTypes = _combosHelpers.GetComboExamTypes()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddExam(ExamViewModel model)
        {
            if (ModelState.IsValid)
            {
                var modelfull = new ExamViewModel
                {
                    DateRegistro = DateTime.Now,
                    EmployeeId = model.EmployeeId,
                    EndDate = model.StartDate.AddYears(1),
                    ExamsType = await _dataContext.ExamsTypes.FindAsync(model.ExamTypeId),
                    Employee = await _dataContext.Employees.FindAsync(model.EmployeeId),
                    StartDate = model.StartDate,
                    UserRegistra = User.Identity.Name,
                    ExamTypeId = model.ExamTypeId,

                };
                var examen = await _converterHelper.ToExamAsync(modelfull, true);
                _dataContext.Exams.Add(examen);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction($"Details/{model.EmployeeId}");
            }
            model.ExamTypes = _combosHelpers.GetComboExamTypes();
            return View(model);
        }
        public async Task<IActionResult> EditExam(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var exams = await _dataContext.Exams
                .Include(s => s.Employee)
                .Include(e => e.ExamsType)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (exams == null)
            {
                return NotFound();
            }

            return View(_converterHelper.ToExamViewModel(exams));
        }
        [HttpPost]
        public async Task<IActionResult> EditExam(ExamViewModel model)
        {
            if (ModelState.IsValid)
            {
                var modelfull = new Exams
                {
                    Employee = await _dataContext.Employees.FindAsync(model.EmployeeId),
                    EndDate = model.StartDate.AddYears(1).AddDays(1),
                    DateModify = DateTime.Now,
                    ExamsType = await _dataContext.ExamsTypes.FindAsync(model.ExamTypeId),
                    Id = model.Id,
                    StartDate = model.StartDate,
                    DateRegistro = model.DateRegistro,
                    UserRegistra = User.Identity.Name,
                    UserModify = User.Identity.Name

                };

                _dataContext.Exams.Update(modelfull);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction($"{nameof(Details)}/{model.EmployeeId}");
                // return RedirectToAction($"Details/{model.SiteId}");
            }
            model.ExamTypes = _combosHelpers.GetComboExamTypes();
            return View(model);
        }


        public async Task<IActionResult> AddIncapacity(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employe = await _dataContext.Employees.FindAsync(id);
            if (employe == null)
            {
                return NotFound();
            }
            var model = new AddIncapacityViewModel
            {
                StartDate = DateTime.Today,
                EmployeeIds = employe.Id,
                TypeNews = _combosHelpers.GetComboTypeNew(),
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddIncapacity(AddIncapacityViewModel model)
        {
            if (ModelState.IsValid)
            {
                var modelfull = new AddIncapacityViewModel
                {
                    DateRegistro = DateTime.Now,
                    Novedad = model.Novedad,
                    EndDate = model.EndDate,
                    Employee = await _dataContext.Employees.FindAsync(model.EmployeeIds),
                    StartDate = model.StartDate,
                    UserRegistra = User.Identity.Name,
                    CantDay = model.CantDay,
                    EmployeeIds = model.EmployeeIds,
                    TypeId = model.TypeId


                };
                var incap = await _converterHelper.ToIncapAsync(modelfull, true);
                _dataContext.Incapacities.Add(incap);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction($"Details/{model.EmployeeIds}");
            }

            return View(model);
        }
        public async Task<IActionResult> EditIncap(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var incap = await _dataContext.Incapacities
                .Include(s => s.Employee)
                .Include(n => n.TypeNew)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (incap == null)
            {
                return NotFound();
            }

            return View(_converterHelper.ToIncapViewModel(incap));
        }
        [HttpPost]
        public async Task<IActionResult> EditIncap(EditIncapacityViewModel model)
        {
            if (ModelState.IsValid)
            {
                var modelfull = new Incapacity
                {
                    Employee = await _dataContext.Employees.FindAsync(model.EmployeeIds),
                    EndDate = model.StartDate.AddDays(model.CantDay),
                    DateModify = DateTime.Now,
                    CantDay = model.CantDay,
                    Novedad = model.Novedad,
                    Id = model.Id,
                    StartDate = model.StartDate,
                    DateRegistro = model.DateRegistro,
                    UserRegistra = model.UserRegistra,
                    UserModify = User.Identity.Name,
                    TypeNew = await _dataContext.TypeNews.FindAsync(model.TypeId)

                };

                _dataContext.Incapacities.Update(modelfull);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction($"{nameof(Details)}/{model.EmployeeIds}");
                // return RedirectToAction($"Details/{model.SiteId}");
            }

            return View();
        }

        public async Task<IActionResult> AddCargos(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employe = await _dataContext.Employees.FindAsync(id);
            if (employe == null)
            {
                return NotFound();
            }
           
            var model = new CargosViewModels
            {
                EmployeeIds = employe.Id ,
                UserRegistra = User.Identity.Name,
                PositionEmployeds = _combosHelpers.GetComboCargos(),
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddCargos(CargosViewModels model)
        {
            var modelfull = new CargosViewModels
            {
                EmployeeIds = model.EmployeeIds,
            
                DateRegistro = DateTime.Now.ToString(),
                PositionId=model.PositionId,
                UserRegistra = User.Identity.Name,


            };

            if (ModelState.IsValid)
            {

                var cargo = await _converterHelper.ToCargosAsync(modelfull, true);
                _dataContext.CargosAsgs.Add(cargo);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction($"Details/{model.EmployeeIds}");
            }
            return View(model);
        }
        public async Task<IActionResult> EditCargos(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var son = await _dataContext.Sons
                .Include(s => s.Employee)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (son == null)
            {
                return NotFound();
            }


            return View(_converterHelper.ToEditSonViewModel(son));
        }

        [HttpPost]
        public async Task<IActionResult> EditCargos(EditSonViewModel model)
        {

            if (ModelState.IsValid)
            {
                var modelfull = new EditSonViewModel
                {
                    Id = model.Id,
                    EmployeeId = model.Id,
                    Datebirth = model.Datebirth,
                    DateRegistro = model.DateRegistro,
                    UserModify = User.Identity.Name,
                    DateModify = DateTime.Now,
                    Genero = model.Genero,
                    Name = model.Name,
                    UserRegistra = model.UserRegistra


                };
                var sons = await _converterHelper.ToEditSonsAsync(modelfull);
                _dataContext.Sons.Update(sons);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction($"{nameof(Details)}/{model.EmployeeId}");
                // return RedirectToAction($"Details/{model.SiteId}");
            }
            return View(model);
        }
        public async Task<IActionResult> AddSons(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employe = await _dataContext.Employees.FindAsync(id);
            if (employe == null)
            {
                return NotFound();
            }
            var model = new SonsViewModel
            {
                EmployeeId = employe.Id,
                UserRegistra = User.Identity.Name

            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddSons(SonsViewModel model)
        {
            var modelfull = new SonsViewModel
            {
                EmployeeId = model.EmployeeId,
                Datebirth = model.Datebirth,
                DateRegistro = DateTime.Now,
                Genero = model.Genero,
                Name = model.Name,
                UserRegistra = User.Identity.Name,


            };

            if (ModelState.IsValid)
            {

                var sons = await _converterHelper.ToSonsAsync(modelfull, true);
                _dataContext.Sons.Add(sons);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction($"Details/{model.EmployeeId}");
            }
            return View(model);
        }
        public async Task<IActionResult> EditSon(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var son = await _dataContext.Sons
                .Include(s => s.Employee)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (son == null)
            {
                return NotFound();
            }


            return View(_converterHelper.ToEditSonViewModel(son));
        }

        [HttpPost]
        public async Task<IActionResult> EditSon(EditSonViewModel model)
        {

            if (ModelState.IsValid)
            {
                var modelfull = new EditSonViewModel
                {
                    Id = model.Id,
                    EmployeeId = model.Id,
                    Datebirth = model.Datebirth,
                    DateRegistro = model.DateRegistro,
                    UserModify = User.Identity.Name,
                    DateModify = DateTime.Now,
                    Genero = model.Genero,
                    Name = model.Name,
                    UserRegistra = model.UserRegistra


                };
                var sons = await _converterHelper.ToEditSonsAsync(modelfull);
                _dataContext.Sons.Update(sons);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction($"{nameof(Details)}/{model.EmployeeId}");
                // return RedirectToAction($"Details/{model.SiteId}");
            }
            return View(model);
        }



        public async Task<IActionResult> AddHistorial(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employe = await _dataContext.Employees.FindAsync(id);
            if (employe == null)
            {
                return NotFound();
            }
            var model = new AddHistorialEmpleadoViewModel
            {
                EmployeeId = employe.Id,
                UserRegistra = User.Identity.Name

            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddHistorial(AddHistorialEmpleadoViewModel model)
        {
            var modelfull = new AddHistorialEmpleadoViewModel
            {
                EmployeeId = model.EmployeeId,
                Fecha = model.Fecha,
                DateRegistro = DateTime.Now,
                Notas = model.Notas,
                UserRegistra = User.Identity.Name,


            };

            if (ModelState.IsValid)
            {

                var historial = await _converterHelper.ToHistorialAsync(modelfull, true);
                _dataContext.HistorialEmpleados.Add(historial);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction($"Details/{model.EmployeeId}");
            }
            return View(model);
        }
        public async Task<IActionResult> EditHistorial(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var historial = await _dataContext.HistorialEmpleados
                .Include(s => s.Employee)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (historial == null)
            {
                return NotFound();
            }


            return View(_converterHelper.ToEditHistorialEmpleadoViewModel(historial));
        }

        [HttpPost]
        public async Task<IActionResult> EditHistorial(EditHistorialEmpleadoViewModel model)
        {

            if (ModelState.IsValid)
            {
                var modelfull = new EditHistorialEmpleadoViewModel
                {
                    Id = model.Id,
                    EmployeeId = model.Id,
                    Fecha = model.Fecha,
                    Notas=model.Notas,
                    DateRegistro = model.DateRegistro,
                    UserModify = User.Identity.Name,
                    DateModify = DateTime.Now,
                   
                    UserRegistra = model.UserRegistra


                };
                var historial = await _converterHelper.ToEditHistorialsAsync(modelfull);
                _dataContext.HistorialEmpleados.Update(historial);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction($"{nameof(Details)}/{model.EmployeeId}");
                // return RedirectToAction($"Details/{model.SiteId}");
            }
            return View(model);
        }


















        public async Task<IActionResult> AddCredit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employe = await _dataContext.Employees.FindAsync(id);
            if (employe == null)
            {
                return NotFound();
            }
            var model = new CreditViewModel
            {

                EmployeeIds = employe.Id,
                StartDate = DateTime.Today,
                Entityes = _combosHelpers.GetComboCreditEntities(),
                UserRegistra = User.Identity.Name
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddCredit(CreditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var modelfull = new CreditViewModel
                {
                    EmployeeIds = model.EmployeeIds,
                    UserRegistra = User.Identity.Name,
                    DateRegistro = DateTime.Now,
                    DeadlinePay = model.DeadlinePay,
                    EndDate = model.EndDate,
                    EntityId = model.EntityId,
                    IsActive = model.IsActive,
                    NumberL = model.NumberL,
                    Quotmonthly = model.Quotmonthly,
                    StartDate = model.StartDate,
                    TotalPrice = model.TotalPrice


                };
                var examen = await _converterHelper.ToCreditAsync(modelfull, true);
                _dataContext.Credits.Add(examen);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction($"Details/{model.EmployeeIds}");
            }
            model.Entityes = _combosHelpers.GetComboCreditEntities();
            return View(model);
        }
        public async Task<IActionResult> EditCredit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var credit = await _dataContext.Credits
                .Include(s => s.Employee)
                .Include(e => e.CreditEntities)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (credit == null)
            {
                return NotFound();
            }

            return View(_converterHelper.ToEditCreditViewModel(credit));
        }

        [HttpPost]
        public async Task<IActionResult> EditCredit(EditCreditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var modelfull = new EditCreditViewModel
                {
                    Id = model.Id,
                    EmployeeIds = model.EmployeeIds,
                    DeadlinePay = model.DeadlinePay,
                    DateRegistro = model.DateRegistro,
                    EndDate = model.EndDate,
                    EntityId = model.EntityId,
                    IsActive = model.IsActive,
                    NumberL = model.NumberL,
                    Quotmonthly = model.Quotmonthly,
                    StartDate = model.StartDate,
                    TotalPrice = model.TotalPrice,
                    UserModify = User.Identity.Name,
                    DateModify = DateTime.Now,

                    UserRegistra = model.UserRegistra


                };
                var credit = await _converterHelper.ToEditCreditAsync(modelfull);
                _dataContext.Credits.Update(credit);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction($"{nameof(Details)}/{model.EmployeeIds}");
                // return RedirectToAction($"Details/{model.SiteId}");
            }
            model.Entityes = _combosHelpers.GetComboCreditEntities();
            return View(model);
        }

        public async Task<IActionResult> AddPerson(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employe = await _dataContext.Employees.FindAsync(id);
            if (employe == null)
            {
                return NotFound();
            }
            var model = new AddPersonContactViewModel
            {
                EmployeeId = employe.Id,

            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddPerson(AddPersonContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                var personCont = new PersonContact
                {
                    Name = model.Name,
                    DateRegistro = DateTime.Now,
                    relationship = model.relationship,
                    Telephone = model.Telephone,
                    UserRegistra = User.Identity.Name,
                    Employee = await _dataContext.Employees.FindAsync(model.EmployeeId)

                };

                _dataContext.PersonContacts.Add(personCont);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction($"Details/{model.EmployeeId}");
            }
            return View(model);
        }
        public async Task<IActionResult> EditPersonContact(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var person = await _dataContext.PersonContacts
                .Include(s => s.Employee)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(_converterHelper.ToPersonContactViewModel(person));
        }

        [HttpPost]
        public async Task<IActionResult> EditPersonContact(EditPersonVieModel model)
        {
            if (ModelState.IsValid)
            {
                var person = new PersonContact
                {
                    Id = model.Id,
                    Name = model.Name,
                    relationship = model.relationship,
                    Telephone = model.Telephone,
                    Employee = await _dataContext.Employees.FindAsync(model.EmployeeId),
                    UserRegistra = model.UserRegistra,
                    DateRegistro = model.DateRegistro,
                    DateModify = DateTime.Now,
                    UserModify = User.Identity.Name



                };

                _dataContext.PersonContacts.Update(person);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction($"{nameof(Details)}/{model.EmployeeId}");
                // return RedirectToAction($"Details/{model.SiteId}");
            }
            return View(model);
        }


        public async Task<IActionResult> AddEndowment(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employe = await _dataContext.Employees.FindAsync(id);
            if (employe == null)
            {
                return NotFound();
            }
            var model = new AddEndowmentViewModel
            {
                EmployeeId = employe.Id,
                EndowmnetsTypes = _combosHelpers.GetComboEndowmentType(),
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddEndowment(AddEndowmentViewModel model)
        {
            var cant = await _dataContext.EndowmentsTypes.FirstOrDefaultAsync(e => e.Id == model.EndowmentTypeId);
            if (ModelState.IsValid)
            {
                var modelfull = new AddEndowmentViewModel
                {
                    Count = model.Count,
                    DateDelivery = model.DateDelivery,
                    DateRegistro = model.DateRegistro,
                    Detail = model.Detail,
                    Employee = model.Employee,
                    EmployeeId = model.EmployeeId,
                    Size = model.Size,
                    DateVence = model.DateDelivery.AddMonths(cant.EspirationDate),
                    UserRegistra = User.Identity.Name,
                    EndowmentTypeId = model.EndowmentTypeId,
                    EndowmnetsTypes = _combosHelpers.GetComboEndowmentType(),

                };
                var endowments = await _converterHelper.ToAddEndowmentAsync(modelfull, true);
                _dataContext.Endowments.Add(endowments);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction($"Details/{model.EmployeeId}");
            }
            return View(model);
        }
        public async Task<IActionResult> EditEndowment(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var endowment = await _dataContext.Endowments
                
                .Include(s => s.Employee)
                .Include(s => s.EndowmentType)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (endowment == null)
            {
                return NotFound();
            }



            return View(_converterHelper.ToEndowmentViewModel(endowment));
        }

        [HttpPost]
        public async Task<IActionResult> EditEndowment(EditEndowmentVieModel model)
        {
            if (ModelState.IsValid)
            {
                var endowment = new EditEndowmentVieModel
                {
                    Count = model.Count,
                    DateDelivery = model.DateDelivery,
                    DateModify = DateTime.Now,
                    DateRegistro = model.DateRegistro,
                    Detail = model.Detail,
                    EndowmentTypeId= model.EndowmentTypeId,
                    EmployeeId = model.EmployeeId,
                    Id = model.Id,
                    Size = model.Size,
                    DateVence=model.DateVence,
                    
                    UserModify = User.Identity.Name,
                    UserRegistra = model.UserRegistra
                };

                //var credit = await _converterHelper.ToAddEndowmentAsync(endowment);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction($"{nameof(Details)}/{model.EmployeeId}");
                // return RedirectToAction($"Details/{model.SiteId}");
            }
            return View(model);
        }
        public async Task<IActionResult> AddContrato(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employe = await _dataContext.Employees.FindAsync(id);
            if (employe == null)
            {
                return NotFound();
            }
            var model = new ContractViewModel
            {
                EmployeeIds = employe.Id,
                DateEnd = DateTime.Today.AddYears(1),
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddContrato(ContractViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                var modelfull = new ContractViewModel
                {
                    Clausulas = model.Clausulas,
                    DateStart = model.DateStart,
                    Id = model.Id,
                    Note = model.Note,
                    EmployeeIds = model.EmployeeIds,
                  
                    
                    DateEnd = model.DateEnd.AddYears(1),
                   

                };
                var contrato = await _converterHelper.ToContractoAsync(modelfull, true);
                _dataContext.Contracts.Add(contrato);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction($"Details/{model.EmployeeIds}");
            }
            return View(model);
        }
        public async Task<IActionResult> EditContract(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var endowment = await _dataContext.Endowments
                .Include(s => s.Employee)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (endowment == null)
            {
                return NotFound();
            }



            return View(_converterHelper.ToEndowmentViewModel(endowment));
        }

        [HttpPost]
        public async Task<IActionResult> EditContract(EditEndowmentVieModel model)
        {
            if (ModelState.IsValid)
            {
                var endowment = new Endowment
                {
                    Count = model.Count,
                    DateDelivery = model.DateDelivery,
                    DateModify = DateTime.Now,
                    DateRegistro = model.DateRegistro,
                    Detail = model.Detail,
                    Employee = await _dataContext.Employees.FindAsync(model.EmployeeId),
                    Id = model.Id,
                    Size = model.Size,
                    UserModify = User.Identity.Name,
                    UserRegistra = model.UserRegistra
                };

                _dataContext.Endowments.Update(endowment);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction($"{nameof(Details)}/{model.EmployeeId}");
                // return RedirectToAction($"Details/{model.SiteId}");
            }
            return View(model);
        }



        public async Task<IActionResult> DeleteIncap(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exams = await _dataContext.Incapacities
                .Include(pi => pi.Employee)
                .FirstOrDefaultAsync(pi => pi.Id == id.Value);
            if (exams == null)
            {
                return NotFound();
            }


            try
            {
                _dataContext.Incapacities.Remove(exams);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction($"{nameof(Details)}/{exams.Employee.Id}");
            }
            catch (Exception e)
            {

                ViewBag.Message = $"Se a Generado una excepcion no Controlada: {e.Message}."; ;
            }
            return View();
        }



        public async Task<IActionResult> DeleteExam(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exams = await _dataContext.Exams
                .Include(pi => pi.Employee)
                .FirstOrDefaultAsync(pi => pi.Id == id.Value);
            if (exams == null)
            {
                return NotFound();
            }

            _dataContext.Exams.Remove(exams);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction($"{nameof(Details)}/{exams.Employee.Id}");
        }
        public async Task<IActionResult> DeleteEndowment(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endowment = await _dataContext.Endowments
                .Include(pi => pi.Employee)
                .FirstOrDefaultAsync(pi => pi.Id == id.Value);
            if (endowment == null)
            {
                return NotFound();
            }

            _dataContext.Endowments.Remove(endowment);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction($"{nameof(Details)}/{endowment.Employee.Id}");
        }
        public async Task<IActionResult> DeletePersonContac(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personContact = await _dataContext.PersonContacts
                .Include(pi => pi.Employee)
                .FirstOrDefaultAsync(pi => pi.Id == id.Value);
            if (personContact == null)
            {
                return NotFound();
            }

            _dataContext.PersonContacts.Remove(personContact);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction($"{nameof(Details)}/{personContact.Employee.Id}");
        }

        public async Task<IActionResult> DeleteCredit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credit = await _dataContext.Credits
                .Include(pi => pi.Employee)
                .FirstOrDefaultAsync(pi => pi.Id == id.Value);
            if (credit == null)
            {
                return NotFound();
            }

            _dataContext.Credits.Remove(credit);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction($"{nameof(Details)}/{credit.Employee.Id}");
        }
        public async Task<IActionResult> DeleteCargo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargos = await _dataContext.CargosAsgs
                .Include(pi => pi.Employee)
                .FirstOrDefaultAsync(pi => pi.Id == id.Value);
            if (cargos == null)
            {
                return NotFound();
            }

            _dataContext.CargosAsgs.Remove(cargos);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction($"{nameof(Details)}/{cargos.Employee.Id}");
        }
        public async Task<IActionResult> DeleteContrato(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractos = await _dataContext.Contracts
                .Include(pi => pi.Employee)
                .FirstOrDefaultAsync(pi => pi.Id == id.Value);
            if (contractos == null)
            {
                return NotFound();
            }

            _dataContext.Contracts.Remove(contractos);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction($"{nameof(Details)}/{contractos.Employee.Id}");
        }
        public async Task<IActionResult> DeleteSon(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sons = await _dataContext.Sons
                .Include(pi => pi.Employee)
                .FirstOrDefaultAsync(pi => pi.Id == id.Value);
            if (sons == null)
            {
                return NotFound();
            }

            _dataContext.Sons.Remove(sons);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction($"{nameof(Details)}/{sons.Employee.Id}");
        }
        public async Task<IActionResult> DeleteImage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _dataContext.UserImages
                .Include(pi => pi.Employee)
                .FirstOrDefaultAsync(pi => pi.Id == id.Value);
            if (image == null)
            {
                return NotFound();
            }

            _dataContext.UserImages.Remove(image);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction($"{nameof(Details)}/{image.Employee.Id}");
        }


    }
}
