using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers.V1
{
    public class ClientesController : BaseController
    {
        [Authorize()]
        [HttpGet]
        public IActionResult Get()
        {
            var clientS = Api.Configuration.Inject.GetService<Core.Interfaces.Services.IClientService>();
            return Ok(clientS.Get());
        }
    }
}
