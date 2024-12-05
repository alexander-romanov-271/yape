using System;

namespace newyape.DataLayer.Models;

public class RuleEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int FieldId { get; set; }

    public double MinValue { get; set; }

    public double MaxValue { get; set; }

    public List<string> AllowedValues{ get; set; } = [];

    public FieldEntity Field { get; set; } = null!;

    public List<GuidelineEntity> Guideline { get; set; } = []; 

}
