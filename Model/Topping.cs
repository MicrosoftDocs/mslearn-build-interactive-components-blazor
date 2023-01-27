namespace BlazingPizza;

public class Topping
{
    public int Id { get; set; }

    public string Name { get; set; } = default!;

    public decimal Price { get; set; }

    public string GetFormattedPrice() => Price.ToString("0.00");
}
