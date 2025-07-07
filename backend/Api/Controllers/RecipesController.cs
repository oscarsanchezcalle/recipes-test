using Microsoft.AspNetCore.Mvc;
using RecipeManagement.Business.Dtos;
using RecipeManagement.Business.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipeManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeDto>>> GetRecipes()
        {
            var recipes = await _recipeService.GetAllRecipesAsync();
            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeDto>> GetRecipe(int id)
        {
            var recipe = await _recipeService.GetRecipeByIdAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return Ok(recipe);
        }

        [HttpPost]
        public async Task<ActionResult<RecipeDto>> PostRecipe(CreateRecipeDto createRecipeDto)
        {
            var newRecipe = await _recipeService.CreateRecipeAsync(createRecipeDto);
            return CreatedAtAction(nameof(GetRecipe), new { id = newRecipe.Id }, newRecipe);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipe(int id, UpdateRecipeDto updateRecipeDto)
        {
            try
            {
                await _recipeService.UpdateRecipeAsync(id, updateRecipeDto);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Recipe not found")
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            try
            {
                await _recipeService.DeleteRecipeAsync(id);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Recipe not found")
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }
    }
}
