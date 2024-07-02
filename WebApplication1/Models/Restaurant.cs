namespace WebApplication1.Models;

public partial class Restaurant
{
    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public Guid Id { get; set; }

    public Guid? AdminId { get; set; }

    public virtual Admin? Admin { get; set; }

    public virtual ICollection<Drink> Drinks { get; set; } = new List<Drink>();
}
