using GriffonCMS.Domain.Models.Entities.Modules;
using GriffonCMS.Domain.Repositories.Base;
using GriffonCMS.Domain.Services.Base;

namespace GriffonCMS.Domain.Services
{
    public class ModuleService : CrudBaseService<Module, Guid>
    {
        public ModuleService(IRepository<Module, Guid> repository) : base(repository)
        {
        }
    }
}