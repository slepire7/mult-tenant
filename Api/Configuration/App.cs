using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Configuration
{
    public class App
    {
        public static TUser AuthenticatedUser<TUser>(System.Security.Principal.IPrincipal principal = null) where TUser : Helpers.IUserInfo
        {
            if (principal == null)
                principal = System.Threading.Thread.CurrentPrincipal ?? Inject.GetService<Middleware.ApplicationContext>()?.ClaimsPrincipal;
            if (principal == null)
                return Inject.GetService<TUser>();

            var identity = (System.Security.Claims.ClaimsPrincipal)principal;
            var UserInfo = Inject.GetService<TUser>();

            foreach (var prop in UserInfo.GetType().GetProperties())
            {
                var claimProp = identity.Claims.FirstOrDefault(o => o.Type == prop.Name);
                if (claimProp is not null)
                {
                    if (prop.PropertyType == typeof(string)) prop.SetValue(UserInfo, claimProp.Value);
                }
            }
            return UserInfo;
        }
    }
}
