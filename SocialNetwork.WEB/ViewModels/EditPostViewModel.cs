using System;
using System.Collections.Generic;
using FluentValidation.Attributes;
using SocialNetwork.Core;
using SocialNetwork.WEB.Validators;

namespace SocialNetwork.WEB.ViewModels
{
    [Validator(typeof(EditPostViewModelValidator))]
    public class EditPostViewModel
    {
        public long ID { get; set; }
        public string Description { get; set; }
    }
}