using System.ComponentModel.DataAnnotations.Schema;
using Week3.Entities.Abstract;

namespace Week3.Entities.Concrete;

public class ProductFeature : IEntity
{
    public int Id { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }
    public string Color { get; set; }

    [ForeignKey("Id")]
    public Product Product { get; set; }
}