using RecipeService.Models;
using RecipeService.Data;
using Microsoft.EntityFrameworkCore;

namespace RecipeService.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly ApplicationDbContext _context;
        public RecipeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Recipe>> GetRecipesAsync(Guid userId)
        {
            return await _context.Recipes.Where(recipe => recipe.UserId == userId).ToListAsync();
        }
        public async Task<Recipe> GetRecipeByIdAsync(Guid id)
        {
            return await _context.Recipes.FirstOrDefaultAsync(r => r.Id == id);
        }
        public async Task<Recipe> AddRecipeAsync(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();
            return recipe;
        }
        public async Task UpdateRecipeAsync(Recipe recipe)
        {
            _context.Entry(recipe).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteRecipeAsync(Guid id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe != null)
            {
                _context.Recipes.Remove(recipe);
                await _context.SaveChangesAsync();
            }
        }
    }
}
