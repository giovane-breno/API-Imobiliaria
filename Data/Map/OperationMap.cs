using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CorretoraAPI.Models;

namespace CorretoraAPI.Data.Map
{
    public class OperationMap : IEntityTypeConfiguration<Operation>
    {
        public void Configure(EntityTypeBuilder<Operation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.AgentId).HasColumnName("agent_id").IsRequired();
            builder.HasOne(x => x.Agent).WithMany(x => x.Operations).HasForeignKey(x => x.AgentId);

            builder.Property(x => x.CustomerId).HasColumnName("customer_id").IsRequired();
            builder.HasOne(x => x.Customer).WithMany(x => x.Operations).HasForeignKey(x => x.CustomerId);

            builder.Property(x => x.HouseId).HasColumnName("house_id").IsRequired();
            builder.HasOne(x => x.House).WithMany(x => x.Operations).HasForeignKey(x => x.HouseId)
            .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.CreatedAt).HasColumnName("created_at").HasDefaultValue(DateTime.Now);
            builder.Property(x => x.UpdateAt).HasColumnName("updated_at");

            builder.Property(x => x.Price).HasColumnName("price").HasPrecision(8, 2).IsRequired();

        }
    }
}