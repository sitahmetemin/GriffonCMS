using GriffonCMS.Domain.Models.Entities.Base;
using GriffonCMS.Domain.Repositories.Base;
using GriffonCMS.Domain.Services.Abstraction.Base;
using System.Linq.Expressions;

namespace GriffonCMS.Domain.Services.Base
{
    public class CrudBaseService<TEntity, TPK> : ICrudBaseService<TEntity, TPK>
        where TEntity : BaseEntity<TPK>
        where TPK : struct
    {
        protected readonly IRepository<TEntity, TPK> _repository;

        public CrudBaseService(IRepository<TEntity, TPK> repository)
        {
            ArgumentNullException.ThrowIfNull(nameof(repository));

            _repository = repository;
        }

        public virtual async Task Create(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _repository.Create(entity, cancellationToken);
            await _repository.SaveChanges(cancellationToken);
        }

        public virtual async Task Delete(TPK id, CancellationToken cancellationToken = default)
        {
            await _repository.Delete(id, cancellationToken);
            await _repository.SaveChanges(cancellationToken);
        }

        public virtual async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default) => await _repository.Get(predicate, cancellationToken);

        public virtual async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default) => await _repository.GetAll(cancellationToken: cancellationToken);

        public virtual async Task<TEntity> GetById(TPK id, CancellationToken cancellationToken = default) => await _repository.GetById(id, cancellationToken);

        public virtual async Task Update(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _repository.Update(entity, cancellationToken);
            await _repository.SaveChanges(cancellationToken);
        }
    }
}
