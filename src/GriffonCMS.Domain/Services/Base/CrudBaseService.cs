using GriffonCMS.Domain.Models.Entities.Base;
using GriffonCMS.Domain.Repositories.Base;
using GriffonCMS.Domain.Services.Abstraction.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;

namespace GriffonCMS.Domain.Services.Base
{
    public class CrudBaseService<TEntity, TPK> : ICrudBaseService<TEntity, TPK>
        where TEntity : BaseEntity<TPK>
        where TPK : struct
    {
        protected readonly IRepository<TEntity, TPK> Repository;

        public CrudBaseService(IHttpContextAccessor httpContext)
        {
            Repository = (IRepository<TEntity, TPK>)httpContext.HttpContext.RequestServices.GetRequiredService(typeof(IRepository<TEntity, TPK>));
        }

        public virtual async Task Create(TEntity entity, CancellationToken cancellationToken = default)
        {
            await Repository.Create(entity, cancellationToken);
            await Repository.SaveChanges(cancellationToken);
        }

        public virtual async Task Delete(TPK id, CancellationToken cancellationToken = default)
        {
            await Repository.Delete(id, cancellationToken);
            await Repository.SaveChanges(cancellationToken);
        }

        public virtual async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default) => await Repository.Get(predicate, eager: false, cancellationToken);

        public virtual async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default) => await Repository.GetAll(cancellationToken: cancellationToken);

        public virtual async Task<TEntity> GetById(TPK id, CancellationToken cancellationToken = default) => await Repository.GetById(id, eager: false, cancellationToken);

        public virtual async Task Update(TEntity entity, CancellationToken cancellationToken = default)
        {
            await Repository.Update(entity, cancellationToken);
            await Repository.SaveChanges(cancellationToken);
        }
    }
}
