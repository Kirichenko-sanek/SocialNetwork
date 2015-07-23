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
    public class UserInRolesManager<T> : Manager<T>, IUserInRolesManager<T> where T : UserInRoles 
    {
        public UserInRolesManager(IRepository<T> repository, IValidator<T> validator) : base(repository, validator)
        {

        }

    }
}
