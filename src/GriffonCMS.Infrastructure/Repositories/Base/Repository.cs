using GriffonCMS.Domain.Models.Entities.Base;
using GriffonCMS.Domain.Repositories.Base;
using GriffonCMS.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GriffonCMS.Infrastructure.Repositories.Base
{
    public class Repository<TEntity, TPK> : IRepository<TEntity, TPK>, IUnitOfWork
        where TEntity : BaseEntity<TPK>
        where TPK : struct
    {
        private readonly GriffonContext _context;
        private readonly DbSet<TEntity> _set;

        protected DbSet<TEntity> Table => _set;

        protected virtual void Dispose(bool disposing) => _context.Dispose();

        public Repository(GriffonContext context)
        {
            _context = context;
            _set = context.Set<TEntity>();
        }

        public virtual async Task Create(TEntity entity, CancellationToken cancellationToken = default) => await Table.AddAsync(entity, cancellationToken);

        public async Task Delete(TPK id, CancellationToken cancellationToken = default)
        {
            var entity = await GetById(id ,cancellationToken);
            if (entity is not null)
                Table.Remove(entity);
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var query = await Table
                .AsNoTracking()
                .FirstAsync(predicate, cancellationToken);

            return query;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default)
        {
            var query = Table.AsQueryable()
                .AsNoTracking();

            if (predicate != null)
                query.Where(predicate);

            return await query.ToListAsync(cancellationToken);
        }
        public virtual async Task<TEntity> GetById(TPK id, CancellationToken cancellationToken = default) => await Table.FirstAsync(q => q.Id.Equals(id), cancellationToken);

        public virtual async Task<int> SaveChanges(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task Update(TEntity entity, CancellationToken cancellationToken = default) => await Task.Run(() => Table.Update(entity), cancellationToken);
    }
}