using Microsoft.EntityFrameworkCore;

namespace BlazingPizza;

public sealed class PizzaStoreContext : DbContext
{
    public PizzaStoreContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Order> Orders => Set<Order>();

    public DbSet<Pizza> Pizzas => Set<Pizza>();

    public DbSet<PizzaSpecial> Specials => Set<PizzaSpecial>();

    public DbSet<Topping> Toppings => Set<Topping>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuring a many-to-many special -> topping relationship
        // that is friendly for serialization
        modelBuilder.Entity<PizzaTopping>().HasKey(pst => new { pst.PizzaId, pst.ToppingId });
        modelBuilder.Entity<PizzaTopping>().HasOne<Pizza>().WithMany(ps => ps.Toppings);
        modelBuilder.Entity<PizzaTopping>().HasOne(pst => pst.Topping).WithMany();
    }
}