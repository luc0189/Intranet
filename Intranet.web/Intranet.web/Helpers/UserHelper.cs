﻿using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Intranet.web.Data.Entities;
using Intranet.web.Models;
using System.Runtime.CompilerServices;
using System;

namespace Intranet.Web.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;

        public UserHelper(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<User> AddUser(AddUserModel view, string role)
        {
            var user =new User
            {
                Address = view.Address,
                Document = view.Document,
                FirstName = view.FirstName,
                LastName = view.LastName,
                Movil=view.Movil,
                Activo=view.Activo,
               DateRegistro= DateTime.Now,
                Email=view.Username,
                UserName=view.Username
                
            };
            var result = await AddUserAsync(user, view.Password);
            if (result!= IdentityResult.Success)
            {
                return null;

            }
            var newUser = await GetUserByEmailAsync(view.Username);
            await AddUserToRoleAsync(newUser, role);
            return newUser;
        }

        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task AddUserToRoleAsync(User user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }
        }

        public async Task<bool> DeleteUserAsync(string email)
        {
            var user = await GetUserByEmailAsync(email);
            if (user == null)
            {
                return true;
            }

            var response = await _userManager.DeleteAsync(user);
            return response.Succeeded;
        }


        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user;
        }

        public async Task<bool> IsUserInRoleAsync(User user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }

        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await _signInManager.PasswordSignInAsync(
                model.Username,
                model.Password,
                model.RememberMe,
                false);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public Task<IdentityResult> UpdateEmployeAsync(Employee Employe)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IdentityResult> UpdateUserAsync(User user)
        {
            return await _userManager.UpdateAsync(user);
        }
        public async Task<SignInResult> ValidatePasswordAsync(User user, string password)
        {
            return await _signInManager.CheckPasswordSignInAsync(
                user,
                password,
                false);
        }

        public async Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword)
        {
            return await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        }
        public async Task<IdentityResult> ConfirmEmailAsync(User user, string token)
        {
            return await _userManager.ConfirmEmailAsync(user, token);
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(User user)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<User> GetUserByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

    }
}