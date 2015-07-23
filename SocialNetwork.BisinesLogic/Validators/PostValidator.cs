using SocialNetwork.Interfases.Repository;
using SocialNetwork.Interfases.Validator;
using SocialNetwork.Core;

namespace SocialNetwork.BisinesLogic.Validators
{
    public class PostValidator : IValidator<Post>
    {
        private readonly IRepository<Post> _postRepository;
        private readonly IValidator<User> _userValidator;
        private readonly IValidator<Photo> _photoValidator;

        public PostValidator(IRepository<Post> postRepository,
                             IValidator<User> userValidator,
                             IValidator<Photo> photoValidator)
        {
            _postRepository = postRepository;
            _userValidator = userValidator;
            _photoValidator = photoValidator;
        }

        public bool IsValid(Post entity)
        {
            return entity.id_user != 0
                   && entity.Photo != null;

        }
        public bool IsExists(long Id)
        {
            return _postRepository.GetByID(Id) != null;
        }
    }
}
