namespace Core.Model
{
    public class Tenant : BaseEntity
    {
        public string Nome { get; set; }
        public string DbConnection { get; set; }
        public string DbProvider { get; set; }
        public bool IsActive { get; set; }
    }
}
