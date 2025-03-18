using Microsoft.AspNetCore.Mvc;
using server.DBModel;
using server.Model;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetRecipeController : ControllerBase
    {
        private readonly RecipeManagementDbContext _context;

        public GetRecipeController(RecipeManagementDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecipes()
        {
            var recipes = await _context.Recipes
                .Include(r => r.Ingredients)
                .Include(r => r.Instructions)
                .Select(r => new RecipeResponse
                {
                    RecipeId = r.RecipeId,
                    UserId = r.UserId,
                    RecipeName = r.RecipeName,
                    Category = r.Category,
                    ImageUrl = r.ImageUrl,
                    CategoryType = r.CategoryType,
                    CreatedDate = r.CreatedDate,
                    ModifiedDate = r.ModifiedDate,
                    Ingredients = r.Ingredients.Select(i => new IngredientResponse
                    {
                        IngredientId = i.IngredientId,
                        IngredientName = i.IngredientName,
                        Quantity = i.Quantity
                    }).ToList(),
                    Instructions = r.Instructions.Select(i => new InstructionResponse
                    {
                        InstructionId = i.InstructionId,
                        StepOrder = i.StepOrder,
                        InstructionText = i.InstructionText
                    }).ToList()
                })
                .ToListAsync();

            return Ok(recipes);
        }
    }
}
.