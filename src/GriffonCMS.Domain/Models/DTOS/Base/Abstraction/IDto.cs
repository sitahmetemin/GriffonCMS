namespace GriffonCMS.Domain.Models.DTOS.Base.Abstraction
{
    public interface IDto<TPK>
        where TPK : struct
    {
        TPK Id { get; set; }
    }
}