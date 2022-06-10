namespace Gamma.Data.Entities
{
    public class Domain
    {
        public long DomainId { get; set; }
        public User Owner { get; set; } = null!;
        public string Name { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
