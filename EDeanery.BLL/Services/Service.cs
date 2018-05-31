using System.Collections.Generic;
using System.Threading.Tasks;
using EDeanery.BLL.Services.Abstract;
using EDeanery.DAL.Repositories.Abstract;
using EDeanery.DAL.UnitOfWork.Abstract;

namespace EDeanery.BLL.Services
{
    internal abstract class Service<TEntity, TIdentity> : IService<TEntity, TIdentity>
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected abstract IRepository<TEntity, TIdentity> Repository { get; }

        protected Service(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await Repository.AddAsync(entity);
        }

        public virtual async Task DeleteAsync(TIdentity id)
        {
            await Repository.DeleteAsync(id);
            await UnitOfWork.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            Repository.UpdateAsync(entity);
            await UnitOfWork.SaveChangesAsync();
        }

        public virtual async Task<ICollection<TEntity>> GetAll()
        {
            return await Repository.GetAll();
        }

        public virtual async Task<TEntity> GetById(TIdentity id)
        {
            return await Repository.GetById(id);
        }
    }
}