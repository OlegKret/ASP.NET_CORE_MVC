using Microsoft.EntityFrameworkCore;

namespace TrainSchedule.Models
{
    public class TrainContext : DbContext
    {
        public TrainContext(DbContextOptions<TrainContext> options) : base(options) 
        {
            
        }

        public DbSet<Train> Trains { get; set; }
    }
}