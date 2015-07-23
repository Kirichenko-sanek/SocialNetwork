using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

using SocialNetwork.Interfases.Repository;
using SocialNetwork.Core;

namespace SocialNetwork.Data.Repository
{
    public class FriendsRepository<T> : Repository<T>, IFriendsRepository<T> where T : Friends
    {
        public FriendsRepository(DataContext context)
            : base(context)
        {

        }
        public IQueryable<Friends> GetFriendsListById(long Id)
        {
            return _context.Friendses.Where(x => x.id_user == Id);
        }        
    }
}
