using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Intranet.web.Data;
using Intranet.web.Data.Entities;
using Intranet.web.Models;
using Intranet.Web.Helpers;
using Intranet.web.Helpers;

namespace Intranet.web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;
        private readonly ICombosHelpers _combosHelpers;
        private readonly IConverterHelper _converterHelper;

        public EmployeesController(DataContext context,
            IUserHelper userHelper,ICombosHelpers combosHelpers,IConverterHelper converterHelper)
        {
            _dataContext = context;
            _userHelper = userHelper;
           _combosHelpers = combosHelpers;
            _converterHelper = converterHelper;
        }

        // GET: Employees
        public IActionResult Index()
        {
            return View( _dataContext.Employees
                .Include(e => e.User)
                .Include(e=> e.Sons)
                .Include(e=> e.Area)
                .ThenInclude(s=> s.SiteHeadquarters)
                .Include(e => e.PersonContacts)
                .Include(e=> e.Credits)
                .Include(e=> e.Exams)
                .Include(e => e.Endowments));
        }

       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _dataContext.Employees
                .Include (e=> e.User)
                .Include(e => e.Sons)
                .Include(e => e.PersonContacts)
                .Include(e => e.Credits)
                .ThenInclude(c=> c.CreditEntities)
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
                var user =  await CreateUserAsync(model);
                if (user!=null)
                {
                    var employe = new Employee
                    {
                        Credits = new List<Credit>(),
                        Sons = new List<Sons>(),
                        Endowments = new List<Endowment>(),
                        Exams = new List<Exams>(),
                        PersonContacts = new List<PersonContact>(),
                        User= user
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
                Arl = model.Arl
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

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _dataContext.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dataContext.Update(employee);
                    await _dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
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
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _dataContext.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _dataContext.Employees.FindAsync(id);
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
            if (id== null)
            {
                return NotFound();
            }
            var employe = await _dataContext.Employees.FindAsync(id);
            if (employe==null)
            {
                return NotFound();
            }
            var model = new ExamViewModel
            {
                EmployeeId= employe.Id,
                ExamTypes= _combosHelpers.GetComboExamTypes()
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
                .Include(e=> e.CreditEntities)
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
    }
}
