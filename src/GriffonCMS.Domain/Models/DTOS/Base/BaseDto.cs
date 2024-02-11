using GriffonCMS.Domain.Models.DTOS.Base.Abstraction;

namespace GriffonCMS.Domain.Models.DTOS.Base
{
    public record BaseDto<TPK> : IDto<TPK>
        where TPK : struct
    {
        public TPK Id { get; set; }
    }
}