using System.ComponentModel.DataAnnotations;

namespace VasosInteligentes.ViewModel
{
    public class ResetPasswordViewModel
    {
        public string UserId { get; set; }
        public string Token { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "A senha deve ter no minímo 6 caracteres")]

        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "A senha e confirmação da senha não conhecidos")]
        public string ConfirmPassword { get; set; }
    }
}
