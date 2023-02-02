namespace BlazingPizza;

public class OrderWithStatus
{
    // Unrealistic, but more interesting to watch
    public readonly static TimeSpan DeliveryDuration = TimeSpan.FromMinutes(1);
    public readonly static TimeSpan PreparationDuration = TimeSpan.FromSeconds(10);

    public Order Order { get; set; } = default!;

    public string StatusText { get; set; } = default!;

    public bool IsDelivered => StatusText is "Delivered";

    public static OrderWithStatus FromOrder(Order order)
    {
        // To simulate a real backend process, we fake status updates based on the amount
        // of time since the order was placed
        var dispatchTime =
            order.CreatedTime.Add(PreparationDuration);

        var now = DateTime.Now;
        var statusText =
            now < dispatchTime
                ? "Preparing" :
                now < dispatchTime + DeliveryDuration
                    ? "Out for delivery" : "Delivered";

        return new()
        {
            Order = order,
            StatusText = statusText
        };
    }
}
