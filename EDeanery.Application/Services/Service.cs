using System.Collections.Generic;
using System.Threading.Tasks;
using EDeanery.Application.Services.Abstract;
using EDeanery.Persistence.Repositories.Abstract;

namespace EDeanery.Application.Services
{
    internal abstract class Service<TEntity, TIdentity> : IService<TEntity, TIdentity>
    {
        protected IRepository<TEntity, TIdentity> Repository { get; }

        protected Service(IRepository<TEntity, TIdentity> repository)
        {
            Repository = repository;
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await Repository.AddAsync(entity);
        }

        public virtual async Task DeleteAsync(TIdentity id)
        {
            await Repository.DeleteAsync(id);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            await Repository.UpdateAsync(entity);
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