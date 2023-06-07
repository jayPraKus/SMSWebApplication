﻿using SMSWebAppData.Helper;
using SMSWebAppData.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.WebApp.Services.IServices
{
    public interface IAccountServices
    {
        Task<DataResult> LoginAsync(LoginViewModel model);
        Task<DataResult> RegisterAsync(RegisterViewModel model);

    }
}
