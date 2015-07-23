using System;
using System.Linq;
using System.Linq.Expressions;
using SocialNetwork.Core;

namespace SocialNetwork.Interfases.Manager
{
    public interface ICommentsManager<T> : IManager<T> where T : Comments
    {
        Comments GetCommentsByPostId(long Id);
        Comments GetCommentsByDateComments(DateTime Date);
    }
}
