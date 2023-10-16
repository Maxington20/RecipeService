using Microsoft.EntityFrameworkCore;

namespace RecipeService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Models.Recipe> Recipes { get; set; }
    }
}
