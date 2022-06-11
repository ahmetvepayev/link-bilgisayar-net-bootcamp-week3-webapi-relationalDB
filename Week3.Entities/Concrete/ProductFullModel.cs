using Week3.Entities.Abstract;

namespace Week3.Entities.Concrete;

public class ProductFullModel : IEntity
{
    public string CategoryName { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }
}