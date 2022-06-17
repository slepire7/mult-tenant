using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected Helpers.IUserInfo UserInfo => Api.Configuration.App.AuthenticatedUser<Helpers.IUserInfo>();
    }
}
