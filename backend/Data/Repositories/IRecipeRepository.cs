using RecipeManagement.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipeManagement.Data.Repositories
{
    public interface IRecipeRepository
    {
        Task<Recipe> GetByIdAsync(int id);
        Task<IEnumerable<Recipe>> GetAllAsync();
        Task AddAsync(Recipe recipe);
        void Update(Recipe recipe);
        void Delete(Recipe recipe);
        Task<bool> SaveChangesAsync();
    }
}
