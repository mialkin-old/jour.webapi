using System.ComponentModel.DataAnnotations;

namespace Jour.Database
{
    public class DatabaseSettings
    {
        public const string Db = "Db";
        
        [Required(AllowEmptyStrings = false)]
        public string Host { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string Database { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Username { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
    }
}