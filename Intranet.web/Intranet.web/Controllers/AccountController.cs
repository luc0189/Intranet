using Intranet.web.Data;
using Intranet.web.Data.Entities;
using Intranet.web.Helpers;
using Intranet.web.Models;
using Intranet.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
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
        private readonly IMailHelper _mailHelper;

        public AccountController(
            IUserHelper userHelper,
            IConfiguration configuration,
            ICombosHelpers combosHelpers,
            DataContext dataContext,
            IMailHelper mailHelper)
        {
            _userHelper = userHelper;
            _configuration = configuration;
            _combosHelpers = combosHelpers;
            _dataContext = dataContext;
            _mailHelper = mailHelper;
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
        private async Task<User> CheckUserAsync(
            int document,
            string firstName,
            string lastName,
            string email,
            string address,
            string movil,
            string role,
             bool activo

            )
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = movil,
                    Movil = movil,
                    Address = address,
                    Document = document,
                    DateRegistro = DateTime.Today,
                    Activo = activo,


                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, role);
                var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);
            }

            return user;
        }




        public IActionResult Register()
        {
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AddUserModel view)
        {
            if (ModelState.IsValid)
            {
                    
                var user = await _userHelper.AddUser(view, "UserApp");
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "This email is already used.");
                    
                    return View(view);
                }
                                
                var myToken = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                var tokenLink = Url.Action("ConfirmEmail", "Account", new
                {
                    userid = user.Id,
                    token = myToken
                }, protocol: HttpContext.Request.Scheme);

                _mailHelper.SendMail(view.Username, "Intranet Lcs - Email confirmation",
                 $"<table border='0' cellpadding='0' cellspacing='0' width='100%'>" +
                
                 $"<tr>" +
                 $"<td style='padding: 40px 0 30px 0; align=center; bgcolor=#70bbd9'>" +

                 $"</td>" +
                 $"</tr>" +
                 $"<tr>" +
                 $"<td>" +
                $"<table align='center' border='0' cellpadding='0' cellspacing='0' width='600' style='-webkit-box-shadow: 10px 10px 81px -10px rgba(0,0,0,0.75); -moz-box-shadow: 10px 10px 81px -10px rgba(0,0,0,0.75); box-shadow: 10px 10px 81px -10px rgba(0,0,0,0.75);'>" +
                        $"<tr>" +
                             $"<td align='center' bgcolor='#70bbd9' style='padding: 40px 0 30px 0;'>" +
                              $"<h1>Intranet Lcs -Email Confirmation</h1>" +
                                        $"<img src='https://cdn1.iconfinder.com/data/icons/hawcons/32/698922-icon-9-mail-checked-256.png'/>" +
                             $"</td>" +
                        $"</tr>" +
                        $"<tr>" +
                              $"<td  border='0' style='padding: 40px 30px 40px 30px;'>" +
                                       $"<table border='0' cellpadding='0' cellspacing='0' width='100%'>" +
                                               $"<tr>" +
                                                       $"<td  style='color:#153643; font-family:Arial; sans-serif; font-size:24px;'>" +
                                                             $"Activa tu email!" +
                                                      $"</td>" +
                                              $"</tr>" +
                                              $"<tr>" +
                                                     $"<td style = 'padding: 20px 0 30px 0; color: #153643; font-family: Arial, sans-serif; font-size: 16px; line-height: 20px;'>" +
                                                            $"siguiendo el link a continuacion <a href=\"{tokenLink}\">Confirm Email</a>" +
                                                     $"</td>" +
                                             $"</tr>" +
                                       $"</table>" +
                              $"</td>" +
                        $"</tr>" +
                        $"<tr>" +
                            $"<td bgcolor='#0c3645' style='color:#ffffff; font-family:Arial, sans-serif; font-size:14px;' bgcolor:'#0c3644'>" +
                                         $"<table  border='1' cellpadding='0' cellspacing='0' width='100%'>" +
                                             $"<tr>" +
                                                 $"<td width='75%' >" +
                                                 $"&reg; LCsystem, Luis Carlos Sanchez Cabrera 2020 <br/>" +
                                                 $"</td>" +
                                                 $"<td align='right'>" +
                                                     $"<table border='0' cellpadding='0' cellspacing='0'>" +
                                                         $"<tr>" +
                                                             $"<td>" +
                                                                 $"LCssystem<a href='https://www.facebook.com/profile.php?id=631602625'>" +
                                                                 $"<img src='https://cdn1.iconfinder.com/data/icons/smallicons-logotypes/32/facebook-48.png' alt='Facebook' width='38' height='38' style='display:block;' border='0'/>" +
                                                                 $"</a>" +
                                                             $"</td>" +
                                                         $"</tr>" +
                                                         $"<tr>" +
                                                             $"<td style='font-size:0; line-height:0;' width ='20'> &nbsp;</td>" +
                                                                 $"Supermio<a href='https://supermio.co'>" +
                                                                 $"<img src='https://supermio.co/wp-content/uploads/2020/04/LOGO_SUPERMIO_boton.png' alt='Supermio sas' width= '38' height='38' style='display:block;' border='0'/>" +
                                                                 $"</a>" +
                                                            $"</td>" +
                                                         $"</tr>" +
                                                     $"</table>" +
                                                 $"</td>" +
                                           $"</tr>" +
                                     $"</table>" +
                           $"</td>" +
                      $"</tr>" +
                 $"</table>" +
            $"</table>" +

                 $"To allow the user, " +
                 $"plase click in this link:</br></br>" +
                 $"<a href = \"{tokenLink}\">Confirm Email</a>");
                ViewBag.Message = $"Se ha Enviado un Email a {view.Username} con Instrucciones para Activar el Usuario.";
                return RedirectToAction("Index", "Home");
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
             
              .FirstOrDefaultAsync(e => e.User.UserName == user.Email);
                var viewm = new EditUserViewModel
                {
                    Id = man.Id,
                    Document = man.User.Document,
                    FirstName = man.User.FirstName,
                    LastName = man.User.LastName,
                    Address = man.User.Address,
                    Movil = man.User.Movil,
                    
                    Activo = man.User.Activo,
                    
                };

            }

            var view = new EditUserViewModel
            {
               
                Document = user.Document,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                Movil = user.Movil,
                
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
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
            {
                return NotFound();
            }

            var user = await _userHelper.GetUserByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userHelper.ConfirmEmailAsync(user, token);
            if (!result.Succeeded)
            {
                return NotFound();
            }

            return View();
        }

    }
}
