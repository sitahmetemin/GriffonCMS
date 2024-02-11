namespace GriffonCMS.Domain.Models.DTOS.Base
{
    public record AuditDto<TPK> : BaseDto<TPK>
        where TPK : struct
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public Guid CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}