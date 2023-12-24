using GriffonCMS.Domain.Models.Entities.Base.Abstracition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GriffonCMS.Domain.Models.Entities.Base
{
    public class BaseEntity<TPK> : IEntity<TPK>
        where TPK : struct
    {
        public TPK Id { get; set; }
    }
}
