using SocialNetwork.Interfases.Repository;
using SocialNetwork.Interfases.Validator;
using SocialNetwork.Core;

namespace SocialNetwork.BisinesLogic.Validators
{
    public class FriendsValidator : IValidator<Friends>
    {
        private readonly IRepository<Friends> _friendsRepository;
        private readonly IValidator<User> _userValidator;

        public FriendsValidator(IRepository<Friends> friendsRepository,
                                IValidator<User> userValidator)
        {
            _friendsRepository = friendsRepository;
            _userValidator = userValidator;
        }

        public bool IsValid(Friends entity)
        {
            return IsExists(entity.id_user)
                   && IsExists(entity.id_friend)
                   && entity.User1 != null
                   && entity.User2 != null;            
        }
        public bool IsExists(long Id)
        {
            return _friendsRepository.GetByID(Id) != null;
        }
    }
}
