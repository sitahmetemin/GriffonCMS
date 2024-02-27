using GriffonCMS.Domain.Models.Entities.Assets;
using GriffonCMS.Domain.Models.Entities.Base;
using GriffonCMS.Domain.Models.Entities.Modules;

namespace GriffonCMS.Domain.Models.Entities.Layouts
{
    public class Layout : AuditEntity<int>
    {
        public required string Name { get; set; }
        public string? Size { get; set; }
        public string? Option { get; set; }

        public int ChannelId { get; set; }
        public required Channel Channel { get; set; }

        public List<Area>? Areas { get; set; }
        public List<Asset>? Assets { get; set; }
        public List<Module>? Modules { get; set; }
    }

    
}