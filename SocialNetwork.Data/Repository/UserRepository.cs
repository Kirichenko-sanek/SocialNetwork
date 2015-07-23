using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

using SocialNetwork.Interfases.Repository;
using SocialNetwork.Core;

namespace SocialNetwork.Data.Repository
{
    public class UserRepository<T> : Repository<T>, IUserRepository<T> where T : User
    {
        public UserRepository(DataContext context)
            : base(context)
        {

        }
        public User GetUserByIEmail(string Email)
        {
           return _context.Useres.FirstOrDefault(x => x.email == Email);
            
        }

        public User GetUserByName(string LastName, string FirstName)
        {
            return _context.Useres.FirstOrDefault(x => (x.first_name == FirstName) && (x.last_name == LastName));
        }

        public User GetUserById(long Id)
        {
            return _context.Useres.FirstOrDefault(x => x.Id == Id);
        }

    }
}
