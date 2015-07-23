using FluentValidation;
using FluentValidation.Mvc;
using SocialNetwork.WEB.App_GlobalResources;
using SocialNetwork.WEB.ViewModels;


namespace SocialNetwork.WEB.Validators
{
    public class PassRecoveryViewModelValidator : AbstractValidator<PassRecoveryViewModel>
    {
        public PassRecoveryViewModelValidator()
        {
            RuleFor(p => p.Email).NotEmpty().WithLocalizedMessage(() => Resource.FieldCannotBeEmpty)
                .EmailAddress().WithLocalizedMessage(() => Resource.WrongFormatEmail);
        }
    }
}