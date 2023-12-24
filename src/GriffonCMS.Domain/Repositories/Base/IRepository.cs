using GriffonCMS.Domain.Models.Entities.Base;
using System.Linq.Expressions;

namespace GriffonCMS.Domain.Repositories.Base
{
    public interface IRepository<TEntity, TPK> : IUnitOfWork
        where TEntity : BaseEntity<TPK>
        where TPK : struct
    {
        Task Create(TEntity entity, CancellationToken cancellationToken = default);

        Task Delete(TPK id, CancellationToken cancellationToken = default);

        Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default);

        Task<TEntity> GetById(TPK id, CancellationToken cancellationToken = default);
        Task Update(TEntity entity, CancellationToken cancellationToken = default);
    }
}
