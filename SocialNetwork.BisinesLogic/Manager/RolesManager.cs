using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using SocialNetwork.Interfases.Repository;
using SocialNetwork.Interfases.Validator;
using SocialNetwork.Interfases.Manager;
using SocialNetwork.Core;

namespace SocialNetwork.BisinesLogic.Manager
{
    public class RolesManager<T> : Manager<T>, IRolesManager<T> where T : Roles
    {
        
        
        private readonly IRolesRepository<Roles> _roleRepository;
       
        public RolesManager(IRolesRepository<Roles> roleRepository,IRepository<T> repository, IValidator<T> validator) : base(repository, validator)
        {
            _roleRepository = roleRepository;
        }
        
        public Roles GetRoleByName(string Name)
        {

            return _roleRepository.GetRoleByName(Name);
        }
    }
}
