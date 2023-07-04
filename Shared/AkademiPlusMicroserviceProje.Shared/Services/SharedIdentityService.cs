﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace AkademiPlusMicroserviceProje.Shared.Services
{
    public class SharedIdentityService:ISharedIdentityService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public SharedIdentityService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string GetUserID => _contextAccessor.HttpContext.User.FindFirst("sub").Value;
    }
}
