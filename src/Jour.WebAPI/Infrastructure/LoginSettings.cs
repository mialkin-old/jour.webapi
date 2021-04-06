using System.ComponentModel.DataAnnotations;

namespace Jour.WebAPI.Infrastructure
{
    public class LoginSettings
    {
        public const string Login = "Login";

        [Required(AllowEmptyStrings = false)]
        public string Username { get; set; }


        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
    }
}
