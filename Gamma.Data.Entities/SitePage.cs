namespace Gamma.Data.Entities
{
    public class SitePage
    {
        public long SitePageId { get; set; }
        public Site Site { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Url { get; set; } = null!;
        public string ContentJson { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
