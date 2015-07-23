using System;
using System.Linq;
using System.Linq.Expressions;
using SocialNetwork.Core;

namespace SocialNetwork.Interfases.Manager
{
    public interface IUserInRolesManager<T> : IManager<T> where T : UserInRoles
    {

    }
}
