using GriffonCMS.Domain.Models.Entities.Base;

namespace GriffonCMS.Domain.Models.Entities.Layouts
{
    public class Area : AuditEntity<int>
    {
        public required string Name { get; set; }
        public string? Size { get; set; }
        public string? Option { get; set; }
        public Layout? Layout { get; set; }
    }
}