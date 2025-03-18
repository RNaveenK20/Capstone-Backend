using System;
using System.Collections.Generic;

namespace server.DBModel;

public partial class Ingredient
{
    public int IngredientId { get; set; }

    public int RecipeId { get; set; }

    public string IngredientName { get; set; } = null!;

    public string? Quantity { get; set; }

    public virtual Recipe Recipe { get; set; } = null!;
}
