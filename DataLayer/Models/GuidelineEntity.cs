using System;

namespace newyape.DataLayer.Models;

public class GuidelineEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public List<ProductEntity> Product { get; set; } = [];

    public List<RuleEntity> Rule { get; set; } = [];

}
