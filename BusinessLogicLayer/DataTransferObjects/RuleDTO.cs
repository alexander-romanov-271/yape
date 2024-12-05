using System;

namespace newyape.BusinessLogicLayer.DataTransferObjects;

public class RuleDTO
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string FieldName { get; set; } = string.Empty;

    public double MinValue { get; set; }

    public double MaxValue { get; set; }

    public List<string> AllowedValues{ get; set; } = [];  

}
