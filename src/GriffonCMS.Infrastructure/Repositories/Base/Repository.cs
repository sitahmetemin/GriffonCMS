using GriffonCMS.Domain.Models.Entities.Base;
using GriffonCMS.Domain.Repositories.Base;
using GriffonCMS.Infrastructure.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;

namespace GriffonCMS.Infrastructure.Repositories.Base
{
    public class Repository<TEntity, TPK> : IRepository<TEntity, TPK>
        where TEntity : BaseEntity<TPK>
        where TPK : struct
    {
        private readonly DbSet<TEntity> _setEntity;
        protected readonly GriffonContext Context;
        protected DbSet<TEntity> Entity => _setEntity;

        protected virtual void Dispose(bool disposing) => Context.Dispose();

        protected void EagerLoad(bool eager, IQueryable<TEntity> query)
        {
            if (eager)
            {
                IEnumerable<string> includableObjects = typeof(TEntity).GetProperties()
                    .Where(q => q.PropertyType.IsByRef && q.PropertyType != typeof(string))
                    .Select(q => q.Name);

                foreach (var property in includableObjects)
                    query.Include(property);
            }

            //if (eager)
            //    foreach (PropertyInfo property in typeof(TEntity).GetProperties().Where(q => q.PropertyType == typeof(BaseEntity<>)))
            //        query.Include(property.Name);
        }
        public Repository(IHttpContextAccessor httpContextAccessor)
        {
            Context = (GriffonContext)httpContextAccessor.HttpContext.RequestServices.GetRequiredService(typeof(GriffonContext));
            _setEntity = Context.Set<TEntity>();
        }

        public virtual async Task Create(TEntity entity, CancellationToken cancellationToken = default) => await _setEntity.AddAsync(entity, cancellationToken);

        public async Task Delete(TPK id, CancellationToken cancellationToken = default)
        {
            var entity = await GetById(id, false, cancellationToken);
            if (entity is not null)
                _setEntity.Remove(entity);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate, bool eager = false, CancellationToken cancellationToken = default)
        {
            var query = _setEntity.AsNoTracking();
            EagerLoad(eager, query);

            return await query.FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>>? predicate = null, bool eager = false, CancellationToken cancellationToken = default)
        {
            var query = _setEntity.AsNoTracking();
            EagerLoad(eager, query);

            if (predicate != null)
                query.Where(predicate);

            return await query.ToListAsync(cancellationToken);
        }

        public virtual async Task<TEntity> GetById(TPK id, bool eager = false, CancellationToken cancellationToken = default)
        {
            var query = _setEntity.AsNoTracking();
            EagerLoad(eager, query);
            return await query.FirstOrDefaultAsync(q => q.Id.Equals(id), cancellationToken);
        }

        public virtual async Task<int> SaveChanges(CancellationToken cancellationToken = default) => await Context.SaveChangesAsync(cancellationToken);

        public virtual async Task Update(TEntity entity, CancellationToken cancellationToken = default) => await Task.Run(() => _setEntity.Update(entity), cancellationToken);
    }
}