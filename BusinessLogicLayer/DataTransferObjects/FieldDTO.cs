using System;

namespace newyape.BusinessLogicLayer.DataTransferObjects;

public class FieldDTO
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    
    public double MinValue { get; set; }

    public double MaxValue { get; set; }

    public List<string> AllowedValues{ get; set; } = [];  

    public string Type { get; set; } = string.Empty;

}
