namespace server.Model
{
    public class RecipeResponse
    {
        public int RecipeId { get; set; }
        public int UserId { get; set; }
        public string RecipeName { get; set; } = string.Empty;
        public string? Category { get; set; }
        public string? ImageUrl { get; set; }
        public string CategoryType { get; set; } = string.Empty;
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public List<IngredientResponse> Ingredients { get; set; } = new List<IngredientResponse>();
        public List<InstructionResponse> Instructions { get; set; } = new List<InstructionResponse>();
    }

    public class IngredientResponse
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; } = string.Empty;
        public string? Quantity { get; set; }
    }

    public class InstructionResponse
    {
        public int InstructionId { get; set; }
        public int StepOrder { get; set; }
        public string InstructionText { get; set; } = string.Empty;
    }
}
