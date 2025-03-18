namespace server.Model
{
    public class AddRecipe
    {
        public int UserId { get; set; }
        public string RecipeName { get; set; } = string.Empty;
        public string? Category { get; set; }
        public string? ImageUrl { get; set; }
        public string CategoryType { get; set; } = string.Empty;
        public List<AddIngredient> Ingredients { get; set; } = new List<AddIngredient>();
        public List<AddInstruction> Instructions { get; set; } = new List<AddInstruction>();
    }

    public class AddIngredient
    {
        public string IngredientName { get; set; } = string.Empty;
        public string? Quantity { get; set; }
    }

    public class AddInstruction
    {
        public int StepOrder { get; set; }
        public string InstructionText { get; set; } = string.Empty;
    }
}
