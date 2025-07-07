using RecipeManagement.Business.Dtos;
using RecipeManagement.Data.Models;
using RecipeManagement.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeManagement.Business.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeService(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task<RecipeDto> GetRecipeByIdAsync(int id)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe == null) return null;

            return new RecipeDto
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Ingredients = recipe.Ingredients,
                Instructions = recipe.Instructions,
                CuisineType = recipe.CuisineType,
                PreparationTime = recipe.PreparationTime,
                Difficulty = recipe.Difficulty,
                NumberOfServings = recipe.NumberOfServings,
                Status = recipe.Status.ToString()
            };
        }

        public async Task<IEnumerable<RecipeDto>> GetAllRecipesAsync()
        {
            var recipes = await _recipeRepository.GetAllAsync();
            return recipes.Select(recipe => new RecipeDto
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Ingredients = recipe.Ingredients,
                Instructions = recipe.Instructions,
                CuisineType = recipe.CuisineType,
                PreparationTime = recipe.PreparationTime,
                Difficulty = recipe.Difficulty,
                NumberOfServings = recipe.NumberOfServings,
                Status = recipe.Status.ToString()
            });
        }

        public async Task<RecipeDto> CreateRecipeAsync(CreateRecipeDto createRecipeDto)
        {
            var recipe = new Recipe
            {
                Name = createRecipeDto.Name,
                Ingredients = createRecipeDto.Ingredients,
                Instructions = createRecipeDto.Instructions,
                CuisineType = createRecipeDto.CuisineType,
                PreparationTime = createRecipeDto.PreparationTime,
                Difficulty = createRecipeDto.Difficulty,
                NumberOfServings = createRecipeDto.NumberOfServings,
                Status = Enum.TryParse(createRecipeDto.Status, out StatusTag status) ? status : StatusTag.None
            };

            await _recipeRepository.AddAsync(recipe);
            await _recipeRepository.SaveChangesAsync();

            return new RecipeDto
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Ingredients = recipe.Ingredients,
                Instructions = recipe.Instructions,
                CuisineType = recipe.CuisineType,
                PreparationTime = recipe.PreparationTime,
                Difficulty = recipe.Difficulty,
                NumberOfServings = recipe.NumberOfServings,
                Status = recipe.Status.ToString()
            };
        }

        public async Task UpdateRecipeAsync(int id, UpdateRecipeDto updateRecipeDto)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe == null) throw new Exception("Recipe not found");

            recipe.Name = updateRecipeDto.Name;
            recipe.Ingredients = updateRecipeDto.Ingredients;
            recipe.Instructions = updateRecipeDto.Instructions;
            recipe.CuisineType = updateRecipeDto.CuisineType;
            recipe.PreparationTime = updateRecipeDto.PreparationTime;
            recipe.Difficulty = updateRecipeDto.Difficulty;
            recipe.NumberOfServings = updateRecipeDto.NumberOfServings;
            recipe.Status = Enum.TryParse(updateRecipeDto.Status, out StatusTag status) ? status : StatusTag.None;

            _recipeRepository.Update(recipe);
            await _recipeRepository.SaveChangesAsync();
        }

        public async Task DeleteRecipeAsync(int id)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe == null) throw new Exception("Recipe not found");

            _recipeRepository.Delete(recipe);
            await _recipeRepository.SaveChangesAsync();
        }
    }
}
