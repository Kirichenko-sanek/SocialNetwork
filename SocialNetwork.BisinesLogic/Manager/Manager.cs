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
    public class Manager<T> : IManager<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;
        private readonly IValidator<T> _validator;
       
        public Manager(IRepository<T> repository, IValidator<T> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public void Add(T entity)
        {
            if (!_validator.IsValid(entity))
                throw new Exception("Entity is not valid.");
            _repository.Add(entity);
            _repository.Save();
        }

        public void Delete(T entity)
        {
            if(!_validator.IsValid(entity))
                throw new Exception("Entity is not valid.");

            _repository.Delete(entity);
            _repository.Save();
        }

        public void Update(T entity)
        {
            if (!_validator.IsExists(entity.Id))
                throw new Exception("Entity doesn't exist.");
            _repository.Update(entity);
            _repository.Save();
        }

        public IQueryable<T> GetAll()
        {
            
            return _repository.GetAll();
        }

        public void Save()
        {
            _repository.Save();
        }

        public T GetByID(long Id)
        {
            if (!_validator.IsExists(Id))
                throw new Exception("Entity doesn't exist.");
            return _repository.GetByID(Id);
        }
    }
}
