using GriffonCMS.Domain.Models.Entities.Base;

namespace GriffonCMS.Domain.Repositories.Base
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChanges(CancellationToken cancellationToken = default);
    }
}
