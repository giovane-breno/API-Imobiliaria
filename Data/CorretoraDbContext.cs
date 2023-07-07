using Microsoft.EntityFrameworkCore;
using CorretoraAPI.Models;
using CorretoraAPI.Data.Map;

namespace CorretoraAPI.Data
{
    public class CorretoraDbContext : DbContext
    {
        public CorretoraDbContext(DbContextOptions<CorretoraDbContext> options) : base(options)
        {
        }

         public DbSet<Operation> Operations { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Customer> Customers { get; set; }


        // public DbSet<OrderProductModel> OrderProducts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OperationMap());
            modelBuilder.ApplyConfiguration(new HouseMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new AgentMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}