
namespace UserService.Domain.Entities
{
    public class Account : BaseEntity
    {
        public string Bank { get; set; }
        public int Number { get; set; }
        public int Agency { get; set; }
        public string OwnerName { get; set; }
        public string OwnerCPF { get; set; }
    }
}
