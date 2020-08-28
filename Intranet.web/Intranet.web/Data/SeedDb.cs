using Intranet.web.Data.Entities;
using Intranet.Web.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        public SeedDb(
            DataContext context,
            IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRoles();
            await ChekPositionAsyn();
            await ChekSiteAsyn();
            await ChekAreaAsyn();
            await ChekEpsAsyn();
            await ChekPensionAsyn();
            await ChekCajaCompAsyn();
            var manager = await CheckUserAsync("1117498993", "Florencia", "Luis Carlos", "Sanchez Cabrera","luc0189@gmail.com",
                                                "Jefe Sistemas", "Milan Caqueta", "Calle Luna Calle Sol",
                                                "O+", true,"3107957939",true,  "Manager","Ingeniero",true);
           var employee = await CheckUserAsync("1121860519", "Florencia", "Yency", "Gonzalez", "yency0187@gmail.com","Aux Registro"
                                              , "Villavicencio", "Calle Luna Calle Sol",
                                              "O+", true, "3107957939", true, "Employe","Tecnologo",false);
            //var lessee = await CheckUserAsync("2020", "Juan", "Zuluaga", "carlos.zuluaga@globant.com", "350 634 2747", "Calle Luna Calle Sol", "Lessee");
           
            await CheckManagerAsync(manager);
            await CheckEmployeAsync(employee);
         
           
        }
        private async Task ChekPositionAsyn()
        {
            if (!_context.PositionEmployees.Any())
            {
                _context.PositionEmployees.Add(new PositionEmployee { 
                    
                    Position = "Administrador" });
                _context.PositionEmployees.Add(new PositionEmployee { 
                  
                    Position = "Jefe Sistemas" });
                _context.PositionEmployees.Add(new PositionEmployee { 
                    
                    Position = "Gerente" });
                _context.PositionEmployees.Add(new PositionEmployee { 
                   
                    Position = "Lider de Tienda" });
               
                await _context.SaveChangesAsync();
            }
        }
        private async Task ChekSiteAsyn()
        {
            if (!_context.SiteHeadquarters.Any())
            {
                _context.SiteHeadquarters.Add(new SiteHeadquarters
                {
                    
                    Nombre = "Administracion"
                });
               

                await _context.SaveChangesAsync();
            }
        }
        private async Task ChekAreaAsyn()
        {
            if (!_context.Areas.Any())
            {
                
                _context.Areas.Add(new Area
                {
                   
                    Nombre = "Sistemas",
                    SiteHeadquarters = await _context.SiteHeadquarters.FirstAsync(o => o.Nombre == "Administracion")
                }); 


                await _context.SaveChangesAsync();
            }
        }
    
        private async Task ChekEpsAsyn()
        {
            if (!_context.Eps.Any())
            {
                _context.Eps.Add(new Eps
                {
                   
                    Nombre = "Coomeva"
                });


                await _context.SaveChangesAsync();
            }
        }
        private async Task ChekPensionAsyn()
        {
            if (!_context.Pensions.Any())
            {
                _context.Pensions.Add(new Pension
                {
                   
                    Nombre = "Porvenir"
                });


                await _context.SaveChangesAsync();
            }
        }
        private async Task ChekCajaCompAsyn()
        {
            if (!_context.CajaCompensacions.Any())
            {
                _context.CajaCompensacions.Add(new CajaCompensacion
                {
                   
                    Nombre = "Comfaca"
                });


                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckEmployeAsync(User user)
        {
            if (!_context.Employees.Any())
            {
                _context.Employees.Add(new Employee {
                    Credits = new List<Credit>(),
                    Sons = new List<Sons>(),
                    Endowments = new List<Endowment>(),
                    Exams = new List<Exams>(),
                    PersonContacts = new List<PersonContact>(),
                    UserImages = new List<UserImages>(),
                    Area = await _context.Areas.FirstAsync(o => o.Id == 1),
                    Eps = await _context.Eps.FirstAsync(o => o.Id == 1),
                    Pension = await _context.Pensions.FirstAsync(o => o.Id == 1),
                    cajaCompensacion = await _context.CajaCompensacions.FirstAsync(o => o.Id == 1),
                    PositionEmployee = await _context.PositionEmployees.FirstAsync(o => o.Id == 1),
                    User = user });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckManagerAsync(User user)
        {
            if (!_context.Managers.Any())
            {
                _context.Managers.Add(new Manager {
                    Credits = new List<Credit>(),
                    Sons = new List<Sons>(),
                    Endowments = new List<Endowment>(),
                    Exams = new List<Exams>(),
                    PersonContacts = new List<PersonContact>(),
                    UserImages = new List<UserImages>(),
                    Area = await _context.Areas.FirstAsync(o => o.Id == 1),
                    Eps = await _context.Eps.FirstAsync(o => o.Id == 1),
                    Pension = await _context.Pensions.FirstAsync(o => o.Id == 1),
                    cajaCompensacion = await _context.CajaCompensacions.FirstAsync(o => o.Id == 1),
                    PositionEmployee = await _context.PositionEmployees.FirstAsync(o => o.Id == 1),

                    User = user});
                await _context.SaveChangesAsync();
            }
        }

        private async Task<User> CheckUserAsync(
            string document,
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
                    Movil= movil,
                    Address = address,
                    Document = document,
                   DateRegistro=DateTime.Now,
                    Activo=activo,
                    
                    
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, role);
                var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);
            }

            return user;
        }


        private async Task CheckRoles()
        {
            await _userHelper.CheckRoleAsync("Manager");
            await _userHelper.CheckRoleAsync("Recursoshumanos");
            await _userHelper.CheckRoleAsync("purchasing");
            await _userHelper.CheckRoleAsync("StoreLeader");
            await _userHelper.CheckRoleAsync("UserApp");
            await _userHelper.CheckRoleAsync("Employe");
        }

      
       

       

      

       
    }
}
