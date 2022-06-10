using Gamma.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gamma.Data.Configurations
{
    public class MediaResourceConfiguration : IEntityTypeConfiguration<MediaResource>
    {
        public void Configure(EntityTypeBuilder<MediaResource> builder)
        {
            builder.HasKey(x => x.MediaResourceId);

            builder.Property(x => x.MediaResourceUid).HasMaxLength(64);
            builder.Property(x => x.Name).HasMaxLength(128);
            builder.Property(x => x.Description).HasMaxLength(2000);
            builder.Property(x => x.DefaultAltText).HasMaxLength(128);
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.UpdatedDate);

            builder.HasOne(x => x.Site).WithMany().HasForeignKey("SiteId").IsRequired().OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Revisions).WithOne(x => x.MediaResource).HasForeignKey("MediaResourceId").IsRequired();
            builder.HasOne(x => x.LastRevision).WithMany().HasForeignKey("LastRevisionId").IsRequired().OnDelete(DeleteBehavior.NoAction);
        }
    }
}
