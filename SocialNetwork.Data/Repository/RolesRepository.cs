using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

using SocialNetwork.Interfases.Repository;
using SocialNetwork.Core;

namespace SocialNetwork.Data.Repository
{
    public class RolesRepository<T> : Repository<T>, IRolesRepository<T> where T: Roles
    {
        public RolesRepository(DataContext context)
            : base(context)
        {

        }
        public Roles GetRoleByName(string Name)
        {
            return _context.Roleses.FirstOrDefault(x => x.name == Name); 
        }
    }
}
