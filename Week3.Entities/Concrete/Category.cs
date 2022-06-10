using Week3.Entities.Abstract;

namespace Week3.Entities.Concrete;

public class Category : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Product> Products { get; set; } = new();
}