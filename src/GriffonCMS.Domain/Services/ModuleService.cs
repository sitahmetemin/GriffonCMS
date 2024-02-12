using GriffonCMS.Domain.Models.Entities.Modules;
using GriffonCMS.Domain.Services.Base;
using Microsoft.AspNetCore.Http;

namespace GriffonCMS.Domain.Services
{
    public class ModuleService : CrudBaseService<Module, int>
    {
        public ModuleService(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
    }
}