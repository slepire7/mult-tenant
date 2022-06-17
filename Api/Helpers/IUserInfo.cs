using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Helpers
{
    public interface IUserInfo
    {
        string Email { get; set; }
        string Tenant { get; set; }
    }
    public class UserInfo : IUserInfo
    {
        public string Email { get; set; }
        public string Tenant { get; set; }
    }
}
