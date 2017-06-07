using System.ComponentModel.DataAnnotations;

namespace Killer_App.Models.Signin
{
    public class SigninModel : BaseModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}