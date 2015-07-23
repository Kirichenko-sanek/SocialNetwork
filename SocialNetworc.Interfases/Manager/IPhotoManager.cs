using System.Web;
using SocialNetwork.Core;

namespace SocialNetwork.Interfases.Manager
{
    public interface IPhotoManager<T> : IManager<T> where T : Photo
    {

    }
}
