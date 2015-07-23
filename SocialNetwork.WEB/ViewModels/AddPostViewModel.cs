using FluentValidation.Attributes;
using SocialNetwork.WEB.Validators;

namespace SocialNetwork.WEB.ViewModels
{
    [Validator(typeof(AddPostViewModelValidator))]
    public class AddPostViewModel
    {
        public string Description { get; set; }
    }
}