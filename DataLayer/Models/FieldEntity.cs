using System;

namespace newyape.DataLayer.Models;

public class FieldEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;

    public double MinValue { get; set; }

    public double MaxValue { get; set; }

    public List<string> AllowedValues{ get; set; } = [];

    public List<RuleEntity> Rule = [];
}