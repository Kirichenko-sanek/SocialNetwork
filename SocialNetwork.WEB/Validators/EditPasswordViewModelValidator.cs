using FluentValidation;
using SocialNetwork.WEB.App_GlobalResources;
using SocialNetwork.WEB.ViewModels;

namespace SocialNetwork.WEB.Validators
{
    public class EditPasswordViewModelValidator : AbstractValidator<EditPasswordViewModel>
    {
        public EditPasswordViewModelValidator()
        {
            RuleFor(p => p.Password).NotEmpty().WithLocalizedMessage(() => Resource.FieldCannotBeEmpty);
            RuleFor(p => p.NewPassword).NotEmpty().WithLocalizedMessage(() => Resource.FieldCannotBeEmpty)
                .Length(6, 20).WithLocalizedMessage(() => Resource.PasswordLenght);
            RuleFor(p => p.ConfirmNewPassword).NotEmpty().WithLocalizedMessage(() => Resource.FieldCannotBeEmpty)
                .Equal(p => p.NewPassword).WithLocalizedMessage(() => Resource.PassMismatch);                
        }
    }
}