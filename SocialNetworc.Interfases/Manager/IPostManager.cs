using System;
using System.Linq;
using System.Linq.Expressions;
using SocialNetwork.Core;

namespace SocialNetwork.Interfases.Manager
{
    public interface IPostManager<T> : IManager<T> where T : Post
    {
        IQueryable<Post> GetUserPostsById(long Id);
        Post GetPostById(long Id);
    }
}
