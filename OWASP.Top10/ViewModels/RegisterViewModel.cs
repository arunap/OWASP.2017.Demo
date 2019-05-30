using System.ComponentModel.DataAnnotations;

namespace OWASP.Top10.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(10)]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(10)]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage ="{0} is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "{0} is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}