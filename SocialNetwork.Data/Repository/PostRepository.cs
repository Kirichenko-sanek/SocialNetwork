using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

using SocialNetwork.Interfases.Repository;
using SocialNetwork.Core;

namespace SocialNetwork.Data.Repository
{
    public class PostRepository<T> : Repository<T>, IPostRepository<T> where T: Post
    {
        public PostRepository(DataContext context)
            : base(context)
        {

        }
        public IQueryable<Post> GetUserPostsById(long Id)
        {
            return _context.Posts.Where(x => x.id_user == Id);
        }

        public Post GetPostById(long Id)
        {
            return _context.Posts.FirstOrDefault(x => x.Id == Id);
        }
    }
}
