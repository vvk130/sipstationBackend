namespace WebApplication1.Models;

public partial class Drink
{
    public string Sku { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string ImgUrl { get; set; } = null!;

    public decimal? Price { get; set; }

    public Guid Id { get; set; }

    public Guid? RestaurantId { get; set; }

    public virtual Restaurant? Restaurant { get; set; }
}
