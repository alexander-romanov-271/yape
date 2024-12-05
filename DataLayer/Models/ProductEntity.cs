namespace newyape.DataLayer.Models;

public class ProductEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description  { get; set; } = string.Empty;

    public List<GuidelineEntity> Guideline { get; set; } = [];
}






