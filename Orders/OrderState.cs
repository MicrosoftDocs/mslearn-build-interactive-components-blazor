namespace BlazingPizza;

public class OrderState
{
    public bool ShowingConfigureDialog => ConfiguringPizza is not null;
    public Pizza? ConfiguringPizza { get; private set; }
    public Order Order { get; private set; } = new();

    public void ShowConfigurePizzaDialog(PizzaSpecial special)
    {
        ConfiguringPizza = new()
        {
            Special = special,
            SpecialId = special.Id,
            Size = Pizza.DefaultSize,
            Toppings = new(),
        };
    }

    public void CancelConfigurePizzaDialog()
    {
        ConfiguringPizza = null;
    }

    public void ConfirmConfigurePizzaDialog()
    {
        Order.Pizzas.Add(ConfiguringPizza!);
        ConfiguringPizza = null;
    }

    public void RemoveConfiguredPizza(Pizza pizza) =>
        Order.Pizzas.Remove(pizza);

    public void ResetOrder() => Order = new();
}
