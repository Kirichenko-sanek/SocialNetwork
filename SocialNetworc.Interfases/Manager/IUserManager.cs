using System;
using System.Linq;
using System.Linq.Expressions;
using SocialNetwork.Core;

namespace SocialNetwork.Interfases.Manager
{
    public interface IUserManager<T> : IManager<T> where T : User
    {
        User GetUserByIEmail(string Email);
        User GetUserByName(string LastName, string FirstName);
        User GetUserById(long Id);
        void SentConfirmMail(T entity, string url);
        void SendPassRecovery(T entity, string newPassword);
        void ActivateUser(T enity);
    }
}
