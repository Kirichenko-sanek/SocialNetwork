using SocialNetwork.Core;

namespace SocialNetwork.Interfases.Validator
{
    public interface IValidator<in T> where T : BaseEntity
    {
        bool IsValid(T entity);
        bool IsExists(long Id);
    }
}
