using Microsoft.EntityFrameworkCore;

namespace weddingPlanner.Models
{
    public class weddingPlannerContext : DbContext
    {
        public weddingPlannerContext(DbContextOptions<weddingPlannerContext> options) : base(options) {}
        // public DbSet<Users> users {get; set;}
        // public DbSet<attending> attending {get; set;}
        // public DbSet<weddings> weddings {get; set;}
    }
}