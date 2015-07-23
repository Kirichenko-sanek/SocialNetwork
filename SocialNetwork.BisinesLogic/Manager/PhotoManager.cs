using System;
using System.IO;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using SocialNetwork.Interfases.Repository;
using SocialNetwork.Interfases.Validator;
using SocialNetwork.Interfases.Manager;
using SocialNetwork.Core;

namespace SocialNetwork.BisinesLogic.Manager
{
    public class PhotoManager<T> : Manager<T>,  IPhotoManager<T> where T : Photo
    {
        public PhotoManager(IRepository<T> repository, IValidator<T> validator) : base(repository, validator)
        {

        }
      
    }
}
