using SocialNetwork.Core;

namespace SocialNetwork.Interfases.Repository
{
    public interface  IUserRepository<T> : IRepository<T> where T : User
    {
        User GetUserByIEmail(string Email);
        User GetUserByName(string LastName, string FirstName);
        User GetUserById(long Id);
        //User ActivateUser(bool Act);
    }
}
