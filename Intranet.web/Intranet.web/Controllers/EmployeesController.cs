using Intranet.web.Data;
using Intranet.web.Data.Entities;
using Intranet.web.Helpers;
using Intranet.web.Models;
using Intranet.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Controllers
{
    [Authorize(Roles = "Manager")]
    public class EmployeesController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;
        private readonly ICombosHelpers _combosHelpers;
        private readonly IConverterHelper _converterHelper;
        private readonly IImageHelper _imageHelper;

        public EmployeesController(DataContext context,
            IUserHelper userHelper,
            ICombosHelpers combosHelpers,
            IConverterHelper converterHelper,
            IImageHelper imageHelper)
        {
            _dataContext = context;
            _userHelper = userHelper;
            _combosHelpers = combosHelpers;
            _converterHelper = converterHelper;
            _imageHelper = imageHelper;
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
                .Include(e => e.User)
                .Include(e => e.Sons)
                .Include(e => e.Area)
                .ThenInclude(s => s.SiteHeadquarters)
                .Include(e => e.PersonContacts)
                .Include(e => e.Credits)
                .Include(e => e.Exams)
                .Include(e => e.Endowments));
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _dataContext.Employees
                .Include(e => e.User)
                .Include(e => e.Sons)
                .Include(e => e.PersonContacts)
                .Include(i => i.UserImages)
                .Include(e => e.Credits)
                .ThenInclude(c => c.CreditEntities)
                .Include(e => e.Exams)
                .ThenInclude(t => t.ExamsType)
                .Include(e => e.Endowments)
                .FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await CreateUserAsync(model);
                if (user != null)
                {
                    var employe = new Employee
                    {
                        Credits = new List<Credit>(),
                        Sons = new List<Sons>(),
                        Endowments = new List<Endowment>(),
                        Exams = new List<Exams>(),
                        PersonContacts = new List<PersonContact>(),
                        UserImages = new List<UserImages>(),
                        User = user
                    };
                    _dataContext.Employees.Add(employe);
                    await _dataContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, "The user Exist");
            }
            return View(model);
        }

        private async Task<User> CreateUserAsync(AddUserViewModel model)
        {
            var user = new User
            {
                Document = model.Document,
                SiteExpedition = model.SiteExpedition,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Username,
                JobTitle = model.JobTitle,
                SiteBirth = model.SiteBirth,
                Address = model.Address,
                Rh = model.Rh,
                License = model.License,
                Movil = model.Movil,
                Arl = model.Arl,
                Activo=model.Activo,
                DateRetiro=model.DateRetiro,
                NivelEducation=model.NivelEducation,
                UserName=model.Username
                
            };
            var result = await _userHelper.AddUserAsync(user, model.Password);
            if (result.Succeeded)
            {
                user = await _userHelper.GetUserByEmailAsync(model.Username);
                await _userHelper.AddUserToRoleAsync(user, "Employe");
                return user;
            }
            return null;
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _dataContext.Employees
                .Include(e => e.User)
                .Include(e => e.UserImages)
                .FirstOrDefaultAsync(e => e.Id == id.Value);
            if (employee == null)
            {
                return NotFound();
            }
            var view = new EditUserViewModel
            {
                Address = employee.User.Address,
                Document = employee.User.Document,
                FirstName = employee.User.FirstName,
                Id = employee.Id,
                LastName = employee.User.LastName,
                License = employee.User.License,
                Arl = employee.User.Arl,
                JobTitle = employee.User.JobTitle,
                Movil = employee.User.Movil,
                Rh = employee.User.Rh,
                SiteBirth = employee.User.SiteBirth,
                SiteExpedition = employee.User.SiteExpedition,
                Activo = employee.User.Activo,
                DateRetiro = employee.User.DateRetiro,
                NivelEducation = employee.User.NivelEducation,


            };
            return View(view);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel vista)
        {
            if (ModelState.IsValid)
            {
                var employe = await _dataContext.Employees
                    .Include(e => e.User)
                    .FirstOrDefaultAsync(e => e.Id == vista.Id);
                employe.User.Document = vista.Document;
                employe.User.Address = vista.Address;
                employe.User.FirstName = vista.FirstName;
                employe.User.LastName = vista.LastName;
                employe.User.License = vista.License;
                employe.User.Arl = vista.Arl;
                employe.User.JobTitle = vista.JobTitle;
                employe.User.Movil = vista.Movil;
                employe.User.Rh = vista.Rh;
                employe.User.SiteBirth = vista.SiteBirth;
                employe.User.NivelEducation = vista.NivelEducation;
                employe.User.Activo = vista.Activo;
                employe.User.DateRetiro = vista.DateRetiro;


                await _userHelper.UpdateUserAsync(employe.User);
                return RedirectToAction(nameof(Index));
            }
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
                .Include(e=> e.User)
                .Include(e=>e.PersonContacts)
                .Include(e=>e.Sons)
                .Include(e=>e.UserImages)
                .Include(e=>e.Endowments)
                .Include(e=>e.Credits)
                
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            if (employee.PersonContacts.Count!=0 ||
                employee.Sons.Count != 0 ||
                employee.UserImages.Count != 0||
                employee.Endowments.Count != 0||
                employee.Credits.Count != 0)
            {
                ModelState.AddModelError(string.Empty, "Valide los detalles antes de Borrar");
                return RedirectToAction(nameof(Index));
            }

            _dataContext.Employees.Remove(employee);
            await _dataContext.SaveChangesAsync();
            await _userHelper.DeleteUserAsync(employee.User.Email);
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
                var examen = await _converterHelper.ToExamAsync(model, true);
                _dataContext.Exams.Add(examen);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction($"Details/{model.EmployeeId}");
            }
            model.ExamTypes = _combosHelpers.GetComboExamTypes();
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

            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddSons(SonsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var sons = await _converterHelper.ToSonsAsync(model, true);
                _dataContext.Sons.Add(sons);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction($"Details/{model.EmployeeId}");
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

                Entityes = _combosHelpers.GetComboCreditEntities()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddCredit(CreditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var examen = await _converterHelper.ToEntitiesCreditAsync(model, true);
                _dataContext.Credits.Add(examen);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction($"Details/{model.EmployeeIds}");
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
                var personal = await _converterHelper.ToPersonAsync(model, true);
                _dataContext.PersonContacts.Add(personal);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction($"Details/{model.EmployeeId}");
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

            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddEndowment(AddEndowmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var endowments = await _converterHelper.ToAddEndowmentAsync(model, true);
                _dataContext.Endowments.Add(endowments);
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

            return View(_converterHelper.ToSonViewModel(son));
        }

        [HttpPost]
        public async Task<IActionResult> EditSon(SonsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var sons = await _converterHelper.ToSonsAsync(model, false);
                _dataContext.Sons.Update(sons);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction($"{nameof(Details)}/{model.EmployeeId}");
                // return RedirectToAction($"Details/{model.SiteId}");
            }
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

            return View(_converterHelper.ToCreditViewModel(credit));
        }

        [HttpPost]
        public async Task<IActionResult> EditCredit(CreditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var credit = await _converterHelper.ToEntitiesCreditAsync(model, false);
                _dataContext.Credits.Update(credit);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction($"{nameof(Details)}/{model.EmployeeIds}");
                // return RedirectToAction($"Details/{model.SiteId}");
            }
            model.Entityes = _combosHelpers.GetComboCreditEntities();
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
        public async Task<IActionResult> EditPersonContact(AddPersonContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                var person = await _converterHelper.ToPersonAsync(model, false);
                _dataContext.PersonContacts.Update(person);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction($"{nameof(Details)}/{model.EmployeeId}");
                // return RedirectToAction($"Details/{model.SiteId}");
            }
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
                var exam = await _converterHelper.ToExamAsync(model, false);
                _dataContext.Exams.Update(exam);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction($"{nameof(Details)}/{model.EmployeeId}");
                // return RedirectToAction($"Details/{model.SiteId}");
            }
            model.ExamTypes = _combosHelpers.GetComboExamTypes();
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
                .FirstOrDefaultAsync(s => s.Id == id);
            if (endowment == null)
            {
                return NotFound();
            }

            return View(_converterHelper.ToEndowmentViewModel(endowment));
        }

        [HttpPost]
        public async Task<IActionResult> EditEndowment(AddEndowmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var endowment = await _converterHelper.ToAddEndowmentAsync(model, false);
                _dataContext.Endowments.Update(endowment);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction($"{nameof(Details)}/{model.EmployeeId}");
                // return RedirectToAction($"Details/{model.SiteId}");
            }
            return View(model);
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
