using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

using SocialNetwork.Interfases.Repository;
using SocialNetwork.Core;

namespace SocialNetwork.Data.Repository
{
    public class UserInRolesRepository<T> : Repository<T>, IUserInRolesRepository<T> where T : UserInRoles
    {
        public UserInRolesRepository(DataContext context)
            : base(context)
        {

        }
    }
}
