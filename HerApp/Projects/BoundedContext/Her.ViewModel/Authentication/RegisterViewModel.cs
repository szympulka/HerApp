using System.ComponentModel.DataAnnotations;

namespace Her.ViewModel.Authentication
{
    public class RegisterViewModel
    {
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
