using RecipeService.Models;

namespace RecipeService.Services
{
    public interface IRecipeService
    {
        Task<IEnumerable<Recipe>> GetRecipesAsync(Guid userId);
        Task<Recipe> GetRecipeByIdAsync(Guid id);
        Task<Recipe> AddRecipeAsync(Recipe recipe);
        Task UpdateRecipeAsync(Recipe recipe);
        Task DeleteRecipeAsync(Guid id);
    }
}
