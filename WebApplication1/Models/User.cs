namespace WebApplication1.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public decimal Wallet { get; set; }

    public string Email { get; set; } = null!;
}
