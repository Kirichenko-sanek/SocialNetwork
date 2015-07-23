using System;
using System.Linq;
using System.Linq.Expressions;
using SocialNetwork.Core;

namespace SocialNetwork.Interfases.Manager
{
    public interface IFriendsManager<T> : IManager<T> where T : Friends
    {
        IQueryable<Friends> GetFriendsListById(long Id);
    }
}
