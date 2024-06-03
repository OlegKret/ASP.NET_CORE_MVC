using Microsoft.EntityFrameworkCore;
using TrainSchedule.Models;

namespace TrainSchedule.Data
{
    public class TrainScheduleDbContext : DbContext
    {
        public TrainScheduleDbContext(DbContextOptions<TrainScheduleDbContext> options) : base(options) { }

        public DbSet<Train> Trains { get; set; } // Create a DbSet for the Train entity

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Train>().ToTable("Train"); // If your table name in the database is not "Trains" 
            modelBuilder.ApplyConfiguration(new TrainDbInitializer()); // Apply your configuration
        }
        
        
    }
}