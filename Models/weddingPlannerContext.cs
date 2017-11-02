using Microsoft.EntityFrameworkCore;

namespace weddingPlanner.Models
{
    public class weddingPlannerContext : DbContext
    {
        public weddingPlannerContext(DbContextOptions<weddingPlannerContext> options) : base(options) {}
        public DbSet<Users> users {get; set;}
        public DbSet<Attending> attending {get; set;}
        public DbSet<Weddings> weddings {get; set;}
    }
}