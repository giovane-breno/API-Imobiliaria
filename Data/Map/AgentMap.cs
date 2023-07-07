using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CorretoraAPI.Models;

namespace CorretoraAPI.Data.Map
{
    public class AgentMap : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnName("name").IsRequired();
            builder.Property(x=>x.Serial).HasColumnName("serial").HasDefaultValue("Default Serial");
            builder.HasMany(x => x.Houses).WithOne(x=>x.Agent).HasForeignKey(x=>x.SellerId);
            builder.HasMany(x => x.Operations).WithOne(x=>x.Agent).HasForeignKey(x=>x.AgentId);

            builder.Property(x => x.CreatedAt).HasColumnName("created_at").HasDefaultValue(DateTime.Now);
            builder.Property(x => x.UpdateAt).HasColumnName("updated_at");
        }
    }
}