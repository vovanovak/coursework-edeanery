using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EDeanery.Mappers.Abstract;
using EDeanery.Persistence.Context.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EDeanery.Persistence.Repositories.Abstract
{
    public abstract class Repository<TEntity, TDao, TIdentity> : IRepository<TEntity, TIdentity> 
        where TEntity : class
        where TDao : class
    {
        protected readonly IEdeaneryDbContext Context;
        protected readonly IMapper<TEntity, TDao> DaoMapper;
        protected readonly IMapper<TDao, TEntity> EntityMapper;

        protected Repository(
            IEdeaneryDbContext context,
            IMapper<TEntity, TDao> daoMapper,
            IMapper<TDao, TEntity> entityMapper)
        {
            Context = context;
            DaoMapper = daoMapper;
            EntityMapper = entityMapper;
        }
        
        protected abstract DbSet<TDao> Table { get; }
        protected abstract IQueryable<TDao> GetWithAllIncludes();
        protected abstract Expression<Func<TDao, bool>> GetDaoById(TIdentity id);
        protected abstract void SetId(TEntity entity, TDao dao);
        
        public async Task AddAsync(TEntity entity)
        {
            var dao = DaoMapper.Map(entity);
            await Table.AddAsync(dao);
            await Context.SaveChangesAsync();
            SetId(entity, dao);
        }

        public async Task DeleteAsync(TIdentity id)
        {
            var dormitory = await Table.SingleOrDefaultAsync(GetDaoById(id));
            Table.Remove(dormitory);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            var dao = DaoMapper.Map(entity);
            Table.Update(dao);
            await Context.SaveChangesAsync();
        }

        public async Task<ICollection<TEntity>> GetAll()
        {
            var daos = await GetWithAllIncludes().ToListAsync();
            return daos.Select(d => EntityMapper.Map(d)).ToList();
        }

        public async Task<TEntity> GetById(TIdentity id)
        {
            var dormitoryEntity = await GetWithAllIncludes().SingleOrDefaultAsync(GetDaoById(id));
            return EntityMapper.Map(dormitoryEntity);
        }
    }
}