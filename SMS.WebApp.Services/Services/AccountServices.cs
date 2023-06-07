﻿using SMS.WebApp.Core.IRepositories;
using SMS.WebApp.Services.IServices;
using SMSWebAppData.Helper;
using SMSWebAppData.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.WebApp.Services.Services
{
    public class AccountServices:IAccountServices
    {
        private readonly IAccountRepositories _accountRepo;
        public AccountServices(IAccountRepositories accountRepo)
        {
            _accountRepo = accountRepo;
        }

        public async Task<DataResult> LoginAsync(LoginViewModel model)
        {
            var result = await _accountRepo.LoginAsync(model);
            return result;
        }

        public async Task<DataResult> RegisterAsync(RegisterViewModel model)
        {
            var result =await _accountRepo.RegisterAsync(model);
            return result;
        }
    }
}
