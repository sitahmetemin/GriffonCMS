using GriffonCMS.Domain.Models.Entities.Base;
using GriffonCMS.Domain.Models.Entities.Layouts;
using GriffonCMS.Domain.Models.Entities.Modules;

namespace GriffonCMS.Domain.Models.Entities.Assets
{
    public class Asset : AuditEntity<int>
    {
        public required string Name { get; set; }
        public required string Size { get; set; }
        public required string Properties { get; set; }
        public string? Option { get; set; }
        public List<Area>? Areas { get; set; }

    }
}