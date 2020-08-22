using System.ComponentModel.DataAnnotations;

namespace SlavesMPEI.Web.Models.ViewModels
{
    public class RegisterViewModel : LoginViewModel
    {
        [Required(ErrorMessage = "Необходимо ввести пароль повторно")]
        [Display(Name = "Повторите пароль")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}