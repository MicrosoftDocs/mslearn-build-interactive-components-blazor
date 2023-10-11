namespace BlazingPizza.Models;

/// <summary>
/// Represents a pre-configured template for a pizza a user can order
/// </summary>
public class PizzaSpecial
{
    public int Id { get; set; }

    public string Name { get; set; } = default!;

    public decimal BasePrice { get; set; }

    public string Description { get; set; } = default!;

    public string ImageUrl { get; set; } = default!;

    public string GetFormattedBasePrice() => BasePrice.ToString("0.00");
}
