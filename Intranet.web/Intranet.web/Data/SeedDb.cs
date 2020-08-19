using Intranet.web.Data.Entities;
using Intranet.Web.Helpers;
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
            var manager = await CheckUserAsync("1117498993", "Florencia", "Luis Carlos", "Sanchez Cabrera","luc0189@gmail.com",
                                                "Jefe Sistemas", "Milan Caqueta", "Calle Luna Calle Sol",
                                                "O+", true,"3107957939",true,  "Manager");
           var employee = await CheckUserAsync("1117498993", "Florencia", "Luis ", "Sanchez ", "luc0187@gmail.com",
                                                "Jefe Sistemas", "Milan Caqueta", "Calle Luna Calle Sol",
                                              "O+", true, "3107957939", true, "Employe");
            //var lessee = await CheckUserAsync("2020", "Juan", "Zuluaga", "carlos.zuluaga@globant.com", "350 634 2747", "Calle Luna Calle Sol", "Lessee");
          
            await CheckManagerAsync(manager);
            await CheckEmployeAsync(employee);
         
           
        }

        private async Task CheckEmployeAsync(User user)
        {
            if (!_context.Employees.Any())
            {
                _context.Employees.Add(new Employee { User = user });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckManagerAsync(User user)
        {
            if (!_context.Managers.Any())
            {
                _context.Managers.Add(new Manager { User = user });
                await _context.SaveChangesAsync();
            }
        }

        private async Task<User> CheckUserAsync(
            string document,
            string siteExpidition,
            string firstName,
            string lastName,
            string email,
            string jodtitle,
            string siteBirh,
            string address,
            string rh,
            bool license,
            string phone,
            bool arl,
            string role)
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
                    PhoneNumber = phone,
                    Movil= phone,
                    Address = address,
                    Document = document,
                    SiteExpedition=siteExpidition,
                    JobTitle=jodtitle,
                    SiteBirth=siteBirh,
                    Rh=rh,
                    License=license,
                    Arl=arl
                    
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, role);
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
