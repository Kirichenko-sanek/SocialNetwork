using FluentValidation;
using SocialNetwork.WEB.App_GlobalResources;
using SocialNetwork.WEB.ViewModels;

namespace SocialNetwork.WEB.Validators
{
    public class EditPostViewModelValidator : AbstractValidator<EditPostViewModel>
    {
        public EditPostViewModelValidator()
        {
            RuleFor(p => p.Description).NotEmpty().WithLocalizedMessage(() => Resource.FieldCannotBeEmpty);
        }
    }
}
