using RecipeService.Models;

namespace RecipeService.Repositories
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Recipe>> GetRecipesAsync(Guid userId);
        Task<Recipe> GetRecipeByIdAsync(Guid id);
        Task<Recipe> AddRecipeAsync(Recipe recipe);
        Task UpdateRecipeAsync(Recipe recipe);
        Task DeleteRecipeAsync(Guid id);
    }
}
