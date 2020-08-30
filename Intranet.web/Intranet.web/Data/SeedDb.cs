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
            await ChekExamTypeAsyn();
            await ChekEpsAsyn();
            await ChekPensionAsyn();
            await ChekCajaCompAsyn();
            var manager = await CheckUserAsync(1117498993, "Luis Carlos", "Sanchez Cabrera","luc0189@gmail.com",
                                                "Calle Luna Calle Sol","3107957939", "Manager",true);
                  
            await CheckManagerAsync(manager);
          
         
           
        }

        private async Task  ChekExamTypeAsyn()
        {
            if (!_context.ExamsTypes.Any())
            {

                _context.ExamsTypes.Add(new ExamsType
                {

                    Name = "Manipulacion De Alimentos",
                    
                });

                await _context.SaveChangesAsync();
            }
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
      
        private async Task CheckManagerAsync(User user)
        {
            if (!_context.Managers.Any())
            {
                _context.Managers.Add(new Manager {
                   
                    User = user});
                await _context.SaveChangesAsync();
            }
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
                    Movil= movil,
                    Address = address,
                    Document = document,
                    DateRegistro=DateTime.Today,
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
         
        }

      
       

       

      

       
    }
}
