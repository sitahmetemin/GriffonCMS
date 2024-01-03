using GriffonCMS.Domain.Models.Entities.Modules;
using GriffonCMS.Domain.Models.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace GriffonCMS.Infrastructure.Contexts
{
    public partial class GriffonContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Module> Modules { get; set; }
    }
}