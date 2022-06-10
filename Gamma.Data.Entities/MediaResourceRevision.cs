namespace Gamma.Data.Entities
{
    public class MediaResourceRevision
    {
        public long MediaResourceRevisionId { get; set; }
        public MediaResource MediaResource { get; set; } = null!;
        public string Url { get; set; } = null!;
        public long Size { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
