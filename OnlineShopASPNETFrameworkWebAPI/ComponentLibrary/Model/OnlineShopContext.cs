using Com.CompanyName.OnlineShop.ComponentLibrary.Entity;
using System.Data.Entity;

namespace Com.CompanyName.OnlineShop.ComponentLibrary.Model
{
    public class OnlineShopContext : DbContext
    {
        public OnlineShopContext() :base("name=OnlineShop")
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

    }
}
