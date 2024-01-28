using GriffonCMS.Domain.Models.Entities.Base;

namespace GriffonCMS.Domain.Models.Entities.Modules
{
    public class Module : AuditEntity<Guid>
    {
        public string Name { get; set; }
        public string Components { get; set; }
    }
}