using GriffonCMS.Domain.Models.Entities.Base;

namespace GriffonCMS.Domain.Models.Entities.Users
{
    public class User : AuditEntity<Guid>
    {
        public required string FirstName { get; set; }
        public required string Lastname { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Mail { get; set; }
    }
}