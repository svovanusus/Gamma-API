using Gamma.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gamma.Data.Configurations
{
    public class MediaResourceRevisionConfiguration : IEntityTypeConfiguration<MediaResourceRevision>
    {
        public void Configure(EntityTypeBuilder<MediaResourceRevision> builder)
        {
            builder.HasKey(x => x.MediaResourceRevisionId);
            
            builder.Property(x => x.Url).HasMaxLength(300);
            builder.Property(x => x.Size);
            builder.Property(x => x.Width);
            builder.Property(x => x.Height);
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.UpdatedDate);
        }
    }
}
