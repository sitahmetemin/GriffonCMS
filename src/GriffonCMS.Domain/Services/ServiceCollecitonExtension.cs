using GriffonCMS.Domain.Services.Abstraction.Base;
using GriffonCMS.Domain.Services.Base;
using Microsoft.Extensions.DependencyInjection;

namespace GriffonCMS.Domain.Services
{
    public static class ServiceCollecitonExtension
    {
        public static void RegisterServices(this IServiceCollection service)
        {
            service.AddScoped(typeof(ICrudBaseService<,>), typeof(CrudBaseService<,>));
        }
    }
}