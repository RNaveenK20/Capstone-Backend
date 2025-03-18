using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.DBModel;
using server.Model;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddRecipeController : ControllerBase
    {
        private readonly RecipeManagementDbContext _context;

        public AddRecipeController(RecipeManagementDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddRecipe addRecipe)
        {
            if (addRecipe == null)
            {
                return BadRequest("Invalid recipe data.");
            }

            // Check if the user exists
            var user = await _context.Users.FindAsync(addRecipe.UserId);
            if (user == null)
            {
                return BadRequest("Invalid user ID.");
            }

            var userId = HttpContext.Items["UserId"]?.ToString();
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID not found.");
            }

            // Create a new Recipe object
            Recipe recipe = new Recipe
            {
                UserId = addRecipe.UserId,
                RecipeName = addRecipe.RecipeName,
                Category = addRecipe.Category,
                ImageUrl = addRecipe.ImageUrl,
                CategoryType = addRecipe.CategoryType,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow
            };

            // Add ingredients
            foreach (var ingredient in addRecipe.Ingredients)
            {
                recipe.Ingredients.Add(new Ingredient
                {
                    IngredientName = ingredient.IngredientName,
                    Quantity = ingredient.Quantity
                });
            }

            // Add instructions
            foreach (var instruction in addRecipe.Instructions)
            {
                recipe.Instructions.Add(new Instruction
                {
                    StepOrder = instruction.StepOrder,
                    InstructionText = instruction.InstructionText
                });
            }

            // Add the recipe to the database
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();

            return Ok("Recipe added successfully.");
        }
    }
}
