using Microsoft.EntityFrameworkCore;
using RecipeService.Data;
using RecipeService.Models;
using RecipeService.Repositories;

namespace RecipeService.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _repository;

        public RecipeService(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Recipe>> GetRecipesAsync(Guid userId)
        {
            return await _repository.GetRecipesAsync(userId);
        }

        public async Task<Recipe> GetRecipeByIdAsync(Guid id)
        {
            return await _repository.GetRecipeByIdAsync(id);
        }

        public async Task<Recipe> AddRecipeAsync(Recipe recipe)
        {
            return await _repository.AddRecipeAsync(recipe);
        }

        public async Task UpdateRecipeAsync(Recipe recipe)
        {
            await _repository.UpdateRecipeAsync(recipe);
        }

        public async Task DeleteRecipeAsync(Guid id)
        {
            await _repository.DeleteRecipeAsync(id);
        }
    }
}
