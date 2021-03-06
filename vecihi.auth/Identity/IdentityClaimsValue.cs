﻿using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace vecihi.auth
{
    public class IdentityClaimsValue
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IdentityClaimsValue(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid UserId()
        {
            return Guid.Parse(_httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == JwtClaimIdentifier.UserId).Value);
        }

        public Type UserId<Type>()
        {
            return helper.Convert.ToGenericType<Type>(UserId().ToString());
        }

        public string UserName()
        {
            return _httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == JwtClaimIdentifier.UserName).Value;
        }
    }
}