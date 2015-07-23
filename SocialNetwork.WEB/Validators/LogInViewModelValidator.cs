using FluentValidation;
using SocialNetwork.WEB.App_GlobalResources;
using SocialNetwork.WEB.Filters;
using SocialNetwork.WEB.ViewModels;

namespace SocialNetwork.WEB.Validators
{
    class LogInViewModelValidator : AbstractValidator<LogInViewModel>
    {
        public LogInViewModelValidator()
        {
            RuleFor(p => p.EmailLogin).NotEmpty().WithLocalizedMessage(() => Resource.FieldCannotBeEmpty)
                .EmailAddress().WithLocalizedMessage(() => Resource.WrongFormatEmail);
            RuleFor(p => p.PasswordLogin).NotEmpty().WithLocalizedMessage(() => Resource.FieldCannotBeEmpty);
        }
    }
}
