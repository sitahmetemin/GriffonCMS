using GriffonCMS.Domain.Models.Entities.Modules;
using GriffonCMS.Domain.Repositories;
using GriffonCMS.Infrastructure.Repositories.Base;
using Microsoft.AspNetCore.Http;

namespace GriffonCMS.Infrastructure.Repositories
{
    public class ModuleRepository : Repository<Module, int>, IModuleRepository
    {
        public ModuleRepository(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }
    }
}