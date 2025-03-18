using System;
using System.Collections.Generic;

namespace server.DBModel;

public partial class Instruction
{
    public int InstructionId { get; set; }

    public int RecipeId { get; set; }

    public int StepOrder { get; set; }

    public string InstructionText { get; set; } = null!;

    public virtual Recipe Recipe { get; set; } = null!;
}
