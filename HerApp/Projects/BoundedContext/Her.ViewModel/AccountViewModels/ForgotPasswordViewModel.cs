using System.ComponentModel.DataAnnotations;

namespace Her.ViewModel.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
