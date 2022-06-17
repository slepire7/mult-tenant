namespace Core.Interfaces.Services
{
    public interface IJwtService
    {
        string CreateToken(Model.User user);
    }
}
