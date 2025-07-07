using Microsoft.EntityFrameworkCore;
using RecipeManagement.Data.Models;

namespace RecipeManagement.Data
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> options) : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
    }
}
