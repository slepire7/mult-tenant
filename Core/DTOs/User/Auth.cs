using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.User
{
    public class ReqAuth
    {
        [EmailAddress(ErrorMessage = "Email Invalido")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class ResAuth
    {
        public string Token { get; set; }
    }
}
