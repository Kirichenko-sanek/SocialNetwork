using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

using SocialNetwork.Interfases.Repository;
using SocialNetwork.Core;


namespace SocialNetwork.Data.Repository
{
    public class PhotoRepository<T> : Repository<T>, IPhotoRepository<T> where T : Photo
    {
        public PhotoRepository(DataContext context)
            : base(context)
        {

        }
        
    }
}
