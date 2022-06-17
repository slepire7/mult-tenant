using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Middleware
{
    public class ApplicationContext
    {
        public System.Security.Claims.ClaimsPrincipal ClaimsPrincipal { get; set; }

        public ApplicationContext(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor.HttpContext != null)
                ClaimsPrincipal = httpContextAccessor.HttpContext.User;
        }
    }
}
