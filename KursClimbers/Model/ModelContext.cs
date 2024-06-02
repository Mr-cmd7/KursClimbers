using Microsoft.EntityFrameworkCore;

namespace KursClimbers.Model
{
    public class ModelContext : DbContext
    {
        public DbSet<Ascent> Ascents { get; set; }
        public DbSet<Climber> Climbers { get; set; }
        public DbSet<ClimbersGroup> ClimbersGroups { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Mountain> Mountains { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-KI26P6P;Initial Catalog=Climbers;Integrated Security=True;Trust Server Certificate=True");
        }
    }
}
