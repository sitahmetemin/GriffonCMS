using GriffonCMS.Domain.Models.DTOS.Base;
using GriffonCMS.Domain.Models.Entities.Layouts;

namespace GriffonCMS.Domain.Models.DTOS.Modules
{
    public record ModuleDto(
        string Name,
        List<Layout>? Layouts) : AuditDto<int>
    {
    }
}