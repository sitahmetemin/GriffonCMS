using GriffonCMS.Domain.Models.Entities.Modules;
using GriffonCMS.Domain.Repositories.Base;

namespace GriffonCMS.Domain.Services.Base
{
    public class ModuleService : CrudBaseService<Module, Guid>
    {
        public ModuleService(IRepository<Module, Guid> repository) : base(repository)
        {
        }
    }
}