using Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Api.Controllers.V1
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("auth")]
        public ActionResult<Core.Utils.ContentResponse<Core.DTOs.User.ResAuth>> Auth([FromBody] Core.DTOs.User.ReqAuth reqAuth)
        {
            var user = _userService.Authentication(reqAuth);

            return new Core.Utils.ContentResponse<Core.DTOs.User.ResAuth>
            {
                IsSuccess = user is not null,
                Data = user
            };
        }
        [Authorize()]
        [HttpGet]
        public IActionResult TesteAuth()
        {
            return Ok(new { Iuser = UserInfo });
        }
    }
}
