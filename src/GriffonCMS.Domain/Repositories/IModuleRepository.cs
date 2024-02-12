using GriffonCMS.Domain.Models.Entities.Modules;
using GriffonCMS.Domain.Repositories.Base;

namespace GriffonCMS.Domain.Repositories
{
    public interface IModuleRepository : IRepository<Module, int>
    {
    }
}