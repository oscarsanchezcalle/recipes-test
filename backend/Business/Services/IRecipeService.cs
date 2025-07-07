using RecipeManagement.Business.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipeManagement.Business.Services
{
    public interface IRecipeService
    {
        Task<RecipeDto> GetRecipeByIdAsync(int id);
        Task<IEnumerable<RecipeDto>> GetAllRecipesAsync();
        Task<RecipeDto> CreateRecipeAsync(CreateRecipeDto createRecipeDto);
        Task UpdateRecipeAsync(int id, UpdateRecipeDto updateRecipeDto);
        Task DeleteRecipeAsync(int id);
    }
}
