using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CorretoraAPI.Models;

namespace CorretoraAPI.Data.Map
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnName("name").IsRequired();
            builder.Property(x => x.Age).HasColumnName("age").IsRequired();

            builder.HasMany(x=>x.Houses).WithOne(x=>x.Customer).HasForeignKey(x=>x.OwnerId);

            builder.Property(x => x.CreatedAt).HasColumnName("created_at").HasDefaultValue(DateTime.Now);
            builder.Property(x => x.UpdateAt).HasColumnName("updated_at");
        }

    }
}