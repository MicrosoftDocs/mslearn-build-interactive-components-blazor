using System.ComponentModel.DataAnnotations;

namespace BlazingPizza;

public class Address
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = default!;

    [Required, MaxLength(100)]
    public string Line1 { get; set; } = default!;

    [MaxLength(100)]
    public string? Line2 { get; set; }

    [Required, MaxLength(50)]
    public string City { get; set; } = default!;

    [Required, MaxLength(20)]
    public string Region { get; set; } = default!;

    [Required, RegularExpression(@"^([0-9]{5})$")]
    public string PostalCode { get; set; } = default!;
}
