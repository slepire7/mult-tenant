namespace Core.Interfaces.Services
{
    public interface IUserService
    {
        DTOs.User.ResAuth Authentication(DTOs.User.ReqAuth data);
    }
}
