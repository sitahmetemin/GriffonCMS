using GriffonCMS.Domain.Models.Entities.Base.Abstracition;

namespace GriffonCMS.Domain.Models.Entities.Base
{
    public class BaseEntity<TPK> : IEntity<TPK>
        where TPK : struct
    {
        public TPK Id { get; set; }
        public required Language Language { get; set; }
    }
}
