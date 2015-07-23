using SocialNetwork.Interfases.Repository;
using SocialNetwork.Interfases.Validator;
using SocialNetwork.Core;

namespace SocialNetwork.BisinesLogic.Validators
{
    public class PhotoValidator : IValidator<Photo>
    {
        private readonly IRepository<Photo> _photoRepository;

        public PhotoValidator(IRepository<Photo> photoRepository)
        {
            _photoRepository = photoRepository;
        }

        public bool IsValid(Photo entity)
        {
            return IsExists(entity.Id);           
        }

        public bool IsExists(long Id)
        {
            return _photoRepository.GetByID(Id) != null;
        }
    }
}
