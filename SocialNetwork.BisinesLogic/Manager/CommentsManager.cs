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
    public class CommentsManager<T> : Manager<T>, ICommentsManager<T> where T : Comments
    {
        private readonly ICommentsRepository<Comments> _commentsRepository;
        
        public CommentsManager(ICommentsRepository<Comments> commentsRepository,IRepository<T> repository, IValidator<T> validator) : base(repository, validator)
        {
            _commentsRepository = commentsRepository;
        }

        public Comments GetCommentsByPostId(long Id)
        {
            return _commentsRepository.GetCommentsByPostId(Id);
        }

        public Comments GetCommentsByDateComments(DateTime Date)
        {
            return _commentsRepository.GetCommentsByDateComments(Date);
        }
    }
}
