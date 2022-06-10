namespace Gamma.Data.Entities
{
    public class MediaResource
    {
        public long MediaResourceId { get; set; }
        public string MediaResourceUid { get; set; } = null!;
        public Site Site { get; set; } = null!;
        public string Name { get; set; } = null!;
        public ICollection<MediaResourceRevision> Revisions { get; set; } = null!;
        public MediaResourceRevision LastRevision { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string DefaultAltText { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
