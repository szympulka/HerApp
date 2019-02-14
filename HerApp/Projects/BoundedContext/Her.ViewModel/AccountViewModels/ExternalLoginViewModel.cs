using System.ComponentModel.DataAnnotations;

namespace Her.ViewModel.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
