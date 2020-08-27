﻿using System.Threading.Tasks;
using Intranet.web.Data.Entities;
using Intranet.web.Models;
using Microsoft.AspNetCore.Identity;



namespace Intranet.Web.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);
        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();
        Task<bool> DeleteUserAsync(string email);
        Task<IdentityResult> UpdateUserAsync(User user);
        Task<IdentityResult> UpdateEmployeAsync(Employee Employe);
        Task<SignInResult> ValidatePasswordAsync(User user, string password);
        Task<User> AddUser(AddUserViewModel view, string role);
        Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword);

        Task<string> GenerateEmailConfirmationTokenAsync(User user);

        Task<IdentityResult> ConfirmEmailAsync(User user, string token);

        Task<User> GetUserByIdAsync(string userId);

    }
}
