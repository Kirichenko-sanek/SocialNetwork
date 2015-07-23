using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Threading.Tasks;

using SocialNetwork.Interfases.Repository;
using SocialNetwork.Interfases.Validator;
using SocialNetwork.Interfases.Manager;
using SocialNetwork.Core;

namespace SocialNetwork.BisinesLogic.Manager
{
    public class PostManager<T> : Manager<T>, IPostManager<T> where T : Post
    {             
        
        private readonly IPostRepository<Post> _postRepository;
        public PostManager(IPostRepository<Post> postRepository, IRepository<T> repository, IValidator<T> validator) : base(repository, validator)
        {
            _postRepository = postRepository;
        }

        public IQueryable<Post> GetUserPostsById(long Id)
        {
            return _postRepository.GetUserPostsById(Id);
        }

        public Post GetPostById(long Id)
        {
            return _postRepository.GetPostById(Id);
        }
    }
}
