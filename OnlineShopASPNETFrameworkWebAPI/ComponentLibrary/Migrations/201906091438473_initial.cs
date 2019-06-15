namespace Com.CompanyName.OnlineShop.ComponentLibrary.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartItems",
                c => new
                {
                    CartItemId = c.Int(nullable: false, identity: true),
                    Quantity = c.Int(nullable: false),
                    CartId = c.Int(nullable: false),
                    ProductId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.CartItemId)
                .ForeignKey("dbo.Carts", t => t.CartId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.CartId)
                .Index(t => t.ProductId);

            CreateTable(
                "dbo.Carts",
                c => new
                {
                    CartId = c.Int(nullable: false, identity: true),
                    Status = c.Int(nullable: false),
                    CustomerId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.CartId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);

            CreateTable(
                "dbo.Customers",
                c => new
                {
                    CustomerId = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50, unicode: false),
                    Email = c.String(maxLength: 256, unicode: false),
                    Password = c.String(maxLength: 50, unicode: false),
                    Address = c.String(maxLength: 100, unicode: false),
                })
                .PrimaryKey(t => t.CustomerId);

            CreateTable(
                "dbo.Products",
                c => new
                {
                    ProductId = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50, unicode: false),
                    Description = c.String(maxLength: 100, unicode: false),
                    CategoryId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);

            CreateTable(
                "dbo.Categories",
                c => new
                {
                    CategoryId = c.Int(nullable: false, identity: true),
                    CategoryName = c.String(nullable: false, maxLength: 50, unicode: false),
                    SubCategoryName = c.String(nullable: false, maxLength: 50, unicode: false),
                })
                .PrimaryKey(t => t.CategoryId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.CartItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Carts", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CartItems", "CartId", "dbo.Carts");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Carts", new[] { "CustomerId" });
            DropIndex("dbo.CartItems", new[] { "ProductId" });
            DropIndex("dbo.CartItems", new[] { "CartId" });
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Customers");
            DropTable("dbo.Carts");
            DropTable("dbo.CartItems");
        }
    }
}
