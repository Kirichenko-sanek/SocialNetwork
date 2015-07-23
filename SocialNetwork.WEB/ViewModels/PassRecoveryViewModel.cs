using FluentValidation.Attributes;
using SocialNetwork.WEB.Validators;

namespace SocialNetwork.WEB.ViewModels
{
    [Validator(typeof(PassRecoveryViewModelValidator))]
    public class PassRecoveryViewModel
    {
        public string Email { get; set; }
        public string Error { get; set; }
    }
}