using System;
using System.Linq;
using System.Linq.Expressions;
using SocialNetwork.Core;

namespace SocialNetwork.Interfases.Manager
{
    public interface IRolesManager<T> : IManager<T> where T : Roles
    {
        Roles GetRoleByName(string Name);
    }
}
