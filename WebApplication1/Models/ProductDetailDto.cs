namespace WebApplication1.Models;

public partial class ProductDetailDto<T>
{
    public required List<double> Statistics { get; set; }
    public required T Item { get; set; }
}
