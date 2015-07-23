using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SocialNetwork.Core;
using SocialNetwork.Interfases.Repository;

namespace SocialNetwork.Interfases.Repository
{
    public interface IFriendsRepository<T> : IRepository<T> where T : Friends
    {
        IQueryable<Friends> GetFriendsListById(long Id);        
    }
}
