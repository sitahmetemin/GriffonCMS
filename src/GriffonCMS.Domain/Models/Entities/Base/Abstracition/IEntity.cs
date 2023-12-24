using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GriffonCMS.Domain.Models.Entities.Base.Abstracition
{
    public interface IEntity<TPK>
        where TPK : struct
    {
        TPK Id { get; set; }
    }
}
