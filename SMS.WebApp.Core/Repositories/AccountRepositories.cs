using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SMS.WebApp.Core.IRepositories;
using SMSWebAppData.Helper;
using SMSWebAppData.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.WebApp.Core.Repositories
{
    public class AccountRepositories : IAccountRepositories
    {
        //Creating object of UserInManger & SignInManager class 
        private readonly UserManager<IdentityUser> _userManager;   //Helps user to register
        private readonly SignInManager<IdentityUser> _signInManager;  //helps user to sign in 
        public AccountRepositories(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<DataResult> LoginAsync(LoginViewModel model)
        {
            DataResult result = new DataResult();
            var user = await _userManager.FindByEmailAsync(model.Email);
            SignInResult signinResult = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (signinResult.Succeeded)
            {
                result.IsSuccess = true;
                result.Message = "User Created successfully";
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "Failed to register user. Try again!";
            }
            return result;

        }

        public async Task<DataResult> RegisterAsync(RegisterViewModel model)
        {
            DataResult result = new DataResult();
            IdentityUser user = new IdentityUser
            {
                UserName = model.UserName,
                Email = model.Email,
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
            IdentityResult response = await _userManager.CreateAsync(user);
            if (response.Succeeded)
            {
                //await _signInManager.SignInAsync(user,false);
                result.IsSuccess = true;
                result.Message = "User Createion success";
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "Failed";
            }
            return result;
        }
        public async Task<String> GetCurrentUserName(HttpContext httpContext)
        {
            var user = await _userManager.GetUserAsync(httpContext.User);
            return user.UserName;

        }

        public async Task<DataResult> LogoutAsync()
        {
            await _signInManager.SignOutAsync();
            DataResult result = new DataResult()
            {
                IsSuccess = true,
                Message = "Logout successfully"
            };
            return result;
            //return  new DataResult(){ IsSuccess = true, Message = "Logout successfully"};


        }
    }
}
