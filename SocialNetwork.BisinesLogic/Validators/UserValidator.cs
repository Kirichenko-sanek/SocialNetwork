using System.Linq;
using SocialNetwork.Interfases.Repository;
using SocialNetwork.Interfases.Validator;
using SocialNetwork.Core;

namespace SocialNetwork.BisinesLogic.Validators
{
    public class UserValidator : IValidator<User>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IValidator<Photo> _photoValidator;

        public UserValidator(IRepository<User> userRepository,
                             IValidator<Photo> photoValidator)
        {
            _userRepository = userRepository;
            _photoValidator = photoValidator;
        }

        public bool IsValid(User entity)
        {
            return _userRepository.GetAll().FirstOrDefault(m => m.email == entity.email) == null
                   && !string.IsNullOrEmpty(entity.first_name)
                   && !string.IsNullOrEmpty(entity.last_name)
                   && !string.IsNullOrEmpty(entity.email)
                   && !string.IsNullOrEmpty(entity.password)
                   && !string.IsNullOrEmpty(entity.password_salt);
        }
        public bool IsExists(long Id)
        {
            return _userRepository.GetByID(Id) != null;
        }
    }
}
