using GriffonCMS.Domain.Models.DTOS.Base.Abstraction;

namespace GriffonCMS.Domain.Models.DTOS.Base
{
    public class BaseDto<TPK> : IDto<TPK>
        where TPK : struct
    {
        public TPK Id { get; set; }
    }
}