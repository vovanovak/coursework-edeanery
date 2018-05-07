using System.Threading.Tasks;
using EDeanery.BLL.Services.Abstract;
using EDeanery.DAL.Repositories.Abstract;
using EDeanery.DAL.UnitOfWork;
using EDeanery.DAL.UnitOfWork.Abstract;

namespace EDeanery.BLL.Services
{
    public abstract class Service<T> : IService<T>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<T> _repository;

        protected Service(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = GetCurrentTypeRepository(_unitOfWork);
        }
        
        public Task AddAsync(T entity)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(T entity)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new System.NotImplementedException();
        }

        public Task GetAll()
        {
            throw new System.NotImplementedException();
        }

        protected abstract IRepository<T> GetCurrentTypeRepository(IUnitOfWork unitOfWork);
    }
}