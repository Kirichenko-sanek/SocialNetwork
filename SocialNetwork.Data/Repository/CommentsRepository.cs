using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

using SocialNetwork.Interfases.Repository;
using SocialNetwork.Core;

namespace SocialNetwork.Data.Repository
{
    public class CommentsRepository<T> : Repository<T>, ICommentsRepository<T> where T :Comments
    {
        public CommentsRepository(DataContext context) : base (context)
        {

        }

        public Comments GetCommentsByPostId(long Id)
        {
            return _context.Commentses.FirstOrDefault(x => x.id_post == Id);
        }

        public Comments GetCommentsByDateComments(DateTime Date)
        {
            return _context.Commentses.FirstOrDefault(x => x.date == Date);
        }
    }
}
