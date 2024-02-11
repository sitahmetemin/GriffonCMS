namespace GriffonCMS.Domain.Models.Entities.Base
{
    public class AuditEntity<TPK> : BaseEntity<TPK>
        where TPK : struct
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public Guid CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}
