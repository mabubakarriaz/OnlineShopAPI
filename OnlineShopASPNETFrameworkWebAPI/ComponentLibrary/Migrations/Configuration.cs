namespace Com.CompanyName.OnlineShop.ComponentLibrary.Migrations
{
    using Com.CompanyName.OnlineShop.ComponentLibrary.Data;
    using Com.CompanyName.OnlineShop.ComponentLibrary.Model;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OnlineShopContext context)
        {
            new SeedData().Create(context);
        }
    }
}
