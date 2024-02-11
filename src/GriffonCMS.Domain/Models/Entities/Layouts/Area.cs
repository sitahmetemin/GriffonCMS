using GriffonCMS.Domain.Models.Entities.Assets;
using GriffonCMS.Domain.Models.Entities.Base;

namespace GriffonCMS.Domain.Models.Entities.Layouts
{
    public class Area : AuditEntity<int>
    {
        public string? Name { get; set; }
        public string? Size { get; set; }
        public string? Option { get; set; }
        public List<Asset>? Assets { get; set; }
        public List<Layout>? Layouts { get; set; }
    }
}