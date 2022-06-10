using Gamma.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gamma.Data.Configurations
{
    public class DomainConfiguration : IEntityTypeConfiguration<Domain>
    {
        public void Configure(EntityTypeBuilder<Domain> builder)
        {
            builder.HasKey(x => x.DomainId);

            builder.Property(x => x.Name).HasMaxLength(128);
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.UpdatedDate);

            builder.HasOne(x => x.Owner).WithMany().HasForeignKey("OwnerId").IsRequired();
        }
    }
}
