using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SocialNetwork.Core;
using SocialNetwork.Interfases.Repository;

namespace SocialNetwork.Interfases.Repository
{
    public interface IRolesRepository<T> : IRepository<T> where T : Roles
    {
        Roles GetRoleByName(string Name);
    }
}
