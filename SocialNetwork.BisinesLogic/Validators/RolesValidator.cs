using SocialNetwork.Interfases.Repository;
using SocialNetwork.Interfases.Validator;
using SocialNetwork.Core;

namespace SocialNetwork.BisinesLogic.Validators
{
    public class RolesValidator : IValidator<Roles>
    {
        private readonly IRepository<Roles> _rolesRepository;

        public RolesValidator(IRepository<Roles> rolesRepository)  
        {
            _rolesRepository = rolesRepository;
        }

        public bool IsValid(Roles entity)
        {
            return !string.IsNullOrEmpty(entity.name);
        }

        public bool IsExists(long Id)
        {
            return _rolesRepository.GetByID(Id) != null;
        }
    }
}
