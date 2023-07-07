using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CorretoraAPI.Models;

namespace CorretoraAPI.Data.Map
{
    public class HouseMap : IEntityTypeConfiguration<House>
    {
        public void Configure(EntityTypeBuilder<House> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Address).HasColumnName("adress").IsRequired();

            builder.Property(x=>x.OwnerId).HasColumnName("owner_id").IsRequired();
            builder.HasOne(x=>x.Customer).WithMany(x=>x.Houses).HasForeignKey(x=>x.OwnerId);

            builder.Property(x=>x.SellerId).HasColumnName("seller_id").IsRequired();
            builder.HasOne(x=>x.Agent).WithMany(x=>x.Houses).HasForeignKey(x=>x.SellerId);
            

            builder.Property(x => x.CreatedAt).HasColumnName("created_at").HasDefaultValue(DateTime.Now);
            builder.Property(x => x.UpdateAt).HasColumnName("updated_at");

        }

    }
}