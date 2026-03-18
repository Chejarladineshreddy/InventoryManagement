using Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
                                                                
            builder.HasKey(p=> p.Id);

            builder.Property(p=>p.Id).UseIdentityColumn().IsRequired();

            builder.HasOne(p => p.category).WithMany(c=>c.Products).HasForeignKey(p=>p.Id);


           
        }
    }
}
