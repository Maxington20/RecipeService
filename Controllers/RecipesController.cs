using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeService.Models;
using RecipeService.Services;

namespace RecipeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes(Guid userId)
        {
            return Ok(await _recipeService.GetRecipesAsync(userId));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipe(Guid id)
        {
            var recipe = await _recipeService.GetRecipeByIdAsync(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        [HttpPost]
        public async Task<ActionResult<Recipe>> CreateRecipe(Recipe recipe)
        {
            await _recipeService.AddRecipeAsync(recipe);
            return CreatedAtAction(nameof(GetRecipe), new { id = recipe.Id }, recipe);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecipe(Guid id, Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return BadRequest();
            }

            await _recipeService.UpdateRecipeAsync(recipe);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(Guid id)
        {
            await _recipeService.DeleteRecipeAsync(id);
            return NoContent();
        }
    }
}
