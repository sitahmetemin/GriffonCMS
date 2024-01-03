using GriffonCMS.Domain.Repositories.Base;
using GriffonCMS.Infrastructure.Repositories.Base;
using Microsoft.Extensions.DependencyInjection;

namespace GriffonCMS.Infrastructure.Repositories
{
    public static class RepositoryCollectionExtension
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        }
    }
}