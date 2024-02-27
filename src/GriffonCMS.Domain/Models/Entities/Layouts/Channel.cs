using GriffonCMS.Domain.Models.Entities.Base;

namespace GriffonCMS.Domain.Models.Entities.Layouts
{
    public class Channel : AuditEntity<int>
    {
        public required string Name { get; set; }

        public required List<Layout> Layouts { get; set; }
    }
}