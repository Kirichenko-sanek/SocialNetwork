using FluentValidation.Attributes;
using SocialNetwork.WEB.Validators;

namespace SocialNetwork.WEB.ViewModels
{
    [Validator(typeof(LogInViewModelValidator))]
    public class LogInViewModel
    {
        public string EmailLogin { get; set; }

        public string PasswordLogin { get; set; }

        public string Error { get; set; }
    }
}
