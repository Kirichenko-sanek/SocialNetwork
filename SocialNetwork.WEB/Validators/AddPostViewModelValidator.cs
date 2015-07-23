using FluentValidation;
using SocialNetwork.WEB.App_GlobalResources;
using SocialNetwork.WEB.ViewModels;

namespace SocialNetwork.WEB.Validators
{
    public class AddPostViewModelValidator : AbstractValidator<AddPostViewModel>
    {
        public AddPostViewModelValidator()
        {
            RuleFor(p => p.Description).NotEmpty().WithLocalizedMessage(() => Resource.FieldCannotBeEmpty);
        }
    }
}