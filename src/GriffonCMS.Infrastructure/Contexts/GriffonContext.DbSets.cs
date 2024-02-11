using GriffonCMS.Domain.Models.Entities.Assets;
using GriffonCMS.Domain.Models.Entities.Authorization;
using GriffonCMS.Domain.Models.Entities.Layouts;
using GriffonCMS.Domain.Models.Entities.Modules;
using GriffonCMS.Domain.Models.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace GriffonCMS.Infrastructure.Contexts
{
    public partial class GriffonContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Layout> Layouts { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
    }
}