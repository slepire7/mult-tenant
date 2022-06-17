using Core.DTOs.User;
using Core.Interfaces.Data;
using Core.Interfaces.Services;
using Core.Model;

namespace Infra.Service
{
    public class UserService : IUserService
    {
        private readonly IJwtService _jwtService;
        private readonly IRepository<User, Infra.Data.AppDbContext> _userRepository;
        public UserService(IJwtService jwtService, IRepository<User, Infra.Data.AppDbContext> userRepository)
        {
            _jwtService = jwtService;
            _userRepository = userRepository;
        }

        public ResAuth Authentication(ReqAuth data)
        {


            var user = _userRepository.GetAndJoinEntity(us => us.Email == data.Email && us.PassWord == data.Password,
            include => include.Tenant);
            return new()
            {
                Token = _jwtService.CreateToken(user)
            };
        }
    }
}
