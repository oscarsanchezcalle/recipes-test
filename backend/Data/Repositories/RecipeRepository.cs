using Microsoft.EntityFrameworkCore;
using RecipeManagement.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipeManagement.Data.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly RecipeContext _context;

        public RecipeRepository(RecipeContext context)
        {
            _context = context;
        }

        public async Task<Recipe> GetByIdAsync(int id)
        {
            return await _context.Recipes.FindAsync(id);
        }

        public async Task<IEnumerable<Recipe>> GetAllAsync()
        {
            return await _context.Recipes.ToListAsync();
        }

        public async Task AddAsync(Recipe recipe)
        {
            await _context.Recipes.AddAsync(recipe);
        }

        public void Update(Recipe recipe)
        {
            _context.Recipes.Update(recipe);
        }

        public void Delete(Recipe recipe)
        {
            _context.Recipes.Remove(recipe);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
