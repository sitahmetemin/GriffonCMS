using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GriffonCMS.Domain.Models.Entities.Base
{
    public class AuditEntity<TPK> : BaseEntity<TPK>
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public Guid CreatedAt { get; set; }
        public Guid? ModifiedAt { get; set; }
    }
}
