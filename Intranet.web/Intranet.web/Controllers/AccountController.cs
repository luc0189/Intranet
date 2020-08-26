using Intranet.web.Data;
using Intranet.web.Helpers;
using Intranet.web.Models;
using Intranet.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserHelper _userHelper;
        private readonly IConfiguration _configuration;
        private readonly ICombosHelpers _combosHelpers;
        private readonly DataContext _dataContext;

        public AccountController(
            IUserHelper userHelper,
            IConfiguration configuration,
            ICombosHelpers combosHelpers,
            DataContext dataContext)
        {
            _userHelper = userHelper;
            _configuration = configuration;
            _combosHelpers = combosHelpers;
            _dataContext = dataContext;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userHelper.LoginAsync(model);
                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "User or password incorrect");
            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _userHelper.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> CreateToken([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userHelper.GetUserByEmailAsync(model.Username);
                if (user != null)
                {
                    var result = await _userHelper.ValidatePasswordAsync(
                        user,
                        model.Password);

                    if (result.Succeeded)
                    {
                        var claims = new[]
                        {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
                        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            _configuration["Tokens:Issuer"],
                            _configuration["Tokens:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddMonths(6),
                            signingCredentials: credentials);
                        var results = new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo
                        };

                        return Created(string.Empty, results);
                    }
                }
            }

            return BadRequest();
        }
        public IActionResult NotAuthorized()
        {
            return View();
        }
        public IActionResult Register()
        {
            var vista = new AddUserViewModel
            {

                Areas = _combosHelpers.GetComboAreas(),
                Eps = _combosHelpers.GetComboEps(),
                Pension = _combosHelpers.GetComboPension(),
                CajaCompensacion = _combosHelpers.GetComboCajaCompensacion(),
                PositionEmplooyed = _combosHelpers.GetComboPositionEmploye(),
                //Roles = _combosHelpers.GetComboRoles(),
            };
            return View(vista);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AddUserViewModel view)
        {
            if (ModelState.IsValid)
            {
                var user = await _userHelper.AddUser(view, "Employe");
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "This email is already used.");
                    return View(view);
                }

                //if (view.RoleId == 1)
                //{
                //    var lessee = new Lessee
                //    {
                //        Contracts = new List<Contract>(),
                //        User = user
                //    };

                //    _dataContext.Lessees.Add(lessee);
                //    await _dataContext.SaveChangesAsync();
                //}
                //else
                //{
                //    var owner = new Owner
                //    {
                //        Contracts = new List<Contract>(),
                //        Properties = new List<Property>(),
                //        User = user
                //    };

                //    _dataContext.Owners.Add(owner);
                //    await _dataContext.SaveChangesAsync();
                //}

                var loginViewModel = new LoginViewModel
                {
                    Password = view.Password,
                    RememberMe = false,
                    Username = view.Username
                };

                var result2 = await _userHelper.LoginAsync(loginViewModel);

                if (result2.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(view);
        }
        public async Task<IActionResult> ChangeUser()
        {
            var user = await _userHelper.GetUserByEmailAsync(User.Identity.Name);
            
            if (user == null)
            {
               var man = await _dataContext.Managers
              .Include(e => e.User)
              .Include(e => e.Sons)
              .Include(e => e.Area)
              .ThenInclude(s => s.SiteHeadquarters)
              .Include(e => e.PersonContacts)
              .Include(e => e.Credits)
              .Include(e => e.PositionEmployee)
              .Include(e => e.Pension)
              .Include(e => e.Eps)

              .Include(e => e.Exams)
              .Include(e => e.cajaCompensacion)
              .Include(e => e.Endowments)
              .FirstOrDefaultAsync(e => e.User.UserName == user.Email);
                var viewm = new EditUserViewModel
                {
                    Id = man.Id,
                    Document = man.User.Document,
                    FirstName = man.User.FirstName,
                    LastName = man.User.LastName,
                    Address = man.User.Address,
                    Movil = man.User.Movil,
                    SiteExpedition = man.User.SiteExpedition,
                    JobTitle = man.User.JobTitle,
                    SiteBirth = man.User.SiteBirth,
                    NivelEducation = man.User.NivelEducation,
                    Rh = man.User.Rh,
                    License = man.User.License,
                    Arl = man.User.Arl,
                    Activo = man.User.Activo,
                    //PositionEmpId = employe.PositionEmployee.Id,
                    //PositionEmplooyed = _combosHelpers.GetComboPositionEmploye(),

                    //PensionId = employe.Pension.Id,
                    //Pension = _combosHelpers.GetComboPension(),

                    //EpsId = employe.Eps.Id,
                    //Eps = _combosHelpers.GetComboEps(),

                    //CajaCompenId = employe.cajaCompensacion.Id,
                    //CajaCompensacion = _combosHelpers.GetComboCajaCompensacion(),

                    //RolId= "Employe",
                    // Roles = _combosHelpers.GetComboRoles(),

                    //AreaId = employe.Area.Id,
                    //Areas = _combosHelpers.GetComboAreas()
                };

            }

            var view = new EditUserViewModel
            {
               
                Document = user.Document,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                Movil = user.Movil,
                SiteExpedition = user.SiteExpedition,
                JobTitle = user.JobTitle,
                SiteBirth = user.SiteBirth,
                NivelEducation = user.NivelEducation,
                Rh = user.Rh,
                License = user.License,
                Arl = user.Arl,
                Activo = user.Activo
               
            };

            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeUser(EditUserViewModel view)
        {
            if (ModelState.IsValid)
            {
                var user = await _userHelper.GetUserByEmailAsync(User.Identity.Name);


                user.Document = view.Document;
                user.FirstName = view.FirstName;
                user.LastName = view.LastName;
                user.Address = view.Address;
                user.Movil = view.Movil;
                user.SiteExpedition = view.SiteExpedition;
                user.JobTitle = view.JobTitle;
                user.NivelEducation = view.NivelEducation;
                user.SiteBirth = view.SiteBirth;
                user.Rh = view.Rh;
                user.License = view.License;
                user.Arl = view.Arl;
                user.Activo = view.Activo;

                await _userHelper.UpdateUserAsync(user);
                return RedirectToAction("Index", "Home");
            }

            return View(view);
        }

        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChagePaswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userHelper.GetUserByEmailAsync(User.Identity.Name);
                if (user != null)
                {
                    var result = await _userHelper.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("ChangeUser");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, result.Errors.FirstOrDefault().Description);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User no found.");
                }
            }

            return View(model);
        }

    }
}
