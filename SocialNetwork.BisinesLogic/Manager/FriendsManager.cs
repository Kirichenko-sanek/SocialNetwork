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
    public class FriendsManager<T> : Manager<T>, IFriendsManager<T> where T : Friends
    {
        private readonly IFriendsRepository<Friends> _friendsRepositori;
        
        public FriendsManager(IFriendsRepository<Friends> friendsRepositori,IRepository<T> repository, IValidator<T> validator) : base(repository, validator)
        {
            _friendsRepositori = friendsRepositori;
        }

        public IQueryable<Friends> GetFriendsListById(long Id)
        {
            return _friendsRepositori.GetFriendsListById(Id);
        }
    }
}
