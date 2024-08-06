using Microsoft.EntityFrameworkCore;

namespace FleetManagement.Models
{
    public class FleetManagementContext : DbContext
    {
        public FleetManagementContext()
        {
        }

        public FleetManagementContext(DbContextOptions<FleetManagementContext> options) : base(options)
        {
        }

    
        public DbSet<Vehicle> Vehicle { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Vehicle>(vehicle =>
            {
                vehicle.HasIndex(x => x.ChassisId).IsUnique(true);
            });
        }
    }
}