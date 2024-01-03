using Microsoft.EntityFrameworkCore;

namespace GriffonCMS.Infrastructure.Contexts
{
    public partial class GriffonContext : DbContext
    {
        public GriffonContext(DbContextOptions options) : base(options)
        {
        }

        protected GriffonContext()
        {
        }
    }
}