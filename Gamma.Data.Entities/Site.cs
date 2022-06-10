namespace Gamma.Data.Entities
{
    public class Site
    {
        public long SiteId { get; set; }
        public User Owner { get; set; } = null!;
        public Domain Domain { get; set; } = null!;
        public string Name { get; set; } = null!;
        public ICollection<SitePage> Pages { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
