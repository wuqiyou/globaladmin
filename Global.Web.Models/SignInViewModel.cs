using System.ComponentModel.DataAnnotations;

namespace Global.Web.Models
{
    public class SignInViewModel : AdminBaseViewModel
    {
        [Required(ErrorMessage="Please enter your email address.")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage="Please enter your password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}