using Microsoft.EntityFrameworkCore;
using PizzaBox.Storing.Entities.EntityModels;

namespace PizzaBox.Storing.Entities
{
  public partial class PizzaDbContext : DbContext
  {

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(@"Server=tcp:project0dbserver.database.windows.net,1433;Initial Catalog=Project0DB;User ID=jeffreybreiner;Password=Wouldyouliketomakeawallet1;");
    }
    public DbSet<DBStore> DBStores { get; set; }
    public DbSet<DBCustomer> DBCustomers { get; set; }
    public DbSet<DBOrder> DBOrders { get; set; }
    public DbSet<DBPizza> DBPizzas { get; set; }
    public DbSet<DBCrust> DBCrusts { get; set; }
    public DbSet<DBSize> DBSizes { get; set; }
    public DbSet<DBTopping> DBToppings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
    }
  }
}
