using SocialNetwork.Interfases.Repository;
using SocialNetwork.Interfases.Validator;
using SocialNetwork.Core;

namespace SocialNetwork.BisinesLogic.Validators
{
    public class UserInRolesValidator : IValidator<UserInRoles>
    {
        private readonly IRepository<UserInRoles> _userInRolesRepository;
        private readonly IValidator<User> _userValidator;
        private readonly IValidator<Roles> _rolesValidator;

        public UserInRolesValidator(IRepository<UserInRoles> userInRolesRepository,
                                    IValidator<User> userValidator,
                                    IValidator<Roles> rolesValidator)
        {
            _userInRolesRepository = userInRolesRepository;
            _userValidator = userValidator;
            _rolesValidator = rolesValidator;
        }

        public bool IsValid(UserInRoles entity)
        {
            return IsExists(entity.id_user)
                   && IsExists(entity.id_roles)
                   && entity.User != null
                   && entity.Roles != null;
        }
        public bool IsExists(long Id)
        {
            return _userInRolesRepository.GetByID(Id) != null;
        }
    }
}
