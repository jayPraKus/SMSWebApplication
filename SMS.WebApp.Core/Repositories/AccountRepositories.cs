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
            var response = await _signInManager.PasswordSignInAsync(model.Email,model.Password,false,false);
            if (response.Succeeded)
            {
                result.IsSuccess= true;
                result.Message = "User login success";
            }
            else
            {
                result.IsSuccess= false;
                result.Message = "No user found";
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
            };
            IdentityResult response =await _userManager.CreateAsync(user);
            if (response.Succeeded)
            {
                await _signInManager.SignInAsync(user,false);
            }
            return result;
        }
    }
}
