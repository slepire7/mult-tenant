using System;

namespace Core.Model
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string PassWord { get; set; }
        public Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }
    }
}
