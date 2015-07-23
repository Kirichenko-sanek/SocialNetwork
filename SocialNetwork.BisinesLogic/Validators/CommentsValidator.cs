using SocialNetwork.Interfases.Repository;
using SocialNetwork.Interfases.Validator;
using SocialNetwork.Core;

namespace SocialNetwork.BisinesLogic.Validators
{
    public class CommentsValidator : IValidator<Comments>
    {
        private readonly IRepository<Comments> _commentsRepository;
        private readonly IValidator<User> _userValidator;
        private readonly IValidator<Post> _postValidator;

        public CommentsValidator(IRepository<Comments> commentsRepository,
                                 IValidator<User> userValidator,
                                 IValidator<Post> postValidator)
        {
            _commentsRepository = commentsRepository;
            _userValidator = userValidator;
            _postValidator = postValidator;
        }

        public bool IsValid(Comments entity)
        {
            return IsExists(entity.id_user)
                   && IsExists(entity.id_post)
                   && entity.User != null
                   && entity.Post != null
                   && !string.IsNullOrEmpty(entity.description);
        }
        public bool IsExists(long Id)
        {
            return _commentsRepository.GetByID(Id) != null;
        }
    }
}
