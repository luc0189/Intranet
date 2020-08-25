using Intranet.web.Data;
using Intranet.web.Helpers;
using Intranet.web.Models;
using Intranet.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
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
                Roles = _combosHelpers.GetComboRoles(),
            };
            return View(vista);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AddUserViewModel view)
        {
            if (ModelState.IsValid)
            {
                var user = await _userHelper.AddUser(view, view.RolId.ToString());
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


    }
}
