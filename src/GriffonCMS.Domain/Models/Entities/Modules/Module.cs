using GriffonCMS.Domain.Models.Entities.Base;
using GriffonCMS.Domain.Models.Entities.Layouts;

namespace GriffonCMS.Domain.Models.Entities.Modules
{
    public class Module : AuditEntity<int>
    {
        public required string Name { get; set; }
        public List<Layout>? Layouts { get; set; }
    }
}