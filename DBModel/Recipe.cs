using System;
using System.Collections.Generic;

namespace server.DBModel;

public partial class Recipe
{
    public int RecipeId { get; set; }

    public int UserId { get; set; }

    public string RecipeName { get; set; } = null!;

    public string? Category { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string CategoryType { get; set; } = null!;

    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    public virtual ICollection<Instruction> Instructions { get; set; } = new List<Instruction>();

    public virtual User User { get; set; } = null!;
}
