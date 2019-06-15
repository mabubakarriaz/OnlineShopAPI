using Com.CompanyName.OnlineShop.ComponentLibrary.Model;
using Com.CompanyName.OnlineShop.ComponentLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.CompanyName.OnlineShop.ComponentLibrary.Types;

namespace Com.CompanyName.OnlineShop.ComponentLibrary.Data
{
    public class SeedData
    {

        public void Create(OnlineShopContext db) {

            //seed values for category
            db.Categories.AddOrUpdate(x => x.CategoryId,
                new Category() { CategoryId = 1, CategoryName = "Electronics", SubCategoryName = "Mobile" },
                new Category() { CategoryId = 2, CategoryName = "Sports", SubCategoryName = "Clothes" },
                new Category() { CategoryId = 3, CategoryName = "Fashion", SubCategoryName = "Shirts" }
                );

            //seed values for product
            db.Products.AddOrUpdate(x => x.ProductId,
                new Product() { ProductId = 1, Name = "IPhone", Description = "Iphone of Description", CategoryId = 1 },
                new Product() { ProductId = 2, Name = "Sweat Pants", Description = "Pants of Description", CategoryId = 2 },
                new Product() { ProductId = 3, Name = "Polo Shirt", Description = "shirt of Description", CategoryId = 3 }
                );

            //seed value for customer
            db.Customers.AddOrUpdate(x => x.CustomerId,
                new Customer() { CustomerId = 1, Name = "Ali", Email = "Ali@company.com", Password = "Ali.123", Address = "67 D Block, Lahore" },
                new Customer() { CustomerId = 2, Name = "Kamran", Email = "Kamran@company.com", Password = "Kamran.123", Address = "78 F Block, Karachi" },
                new Customer() { CustomerId = 3, Name = "Zuhaib", Email = "Zuhaib@company.com", Password = "Zuhaib.123", Address = "22 K Block, Multan" }
                );

            //seed value for cart
            db.Carts.AddOrUpdate(x => x.CartId,
                new Cart() { CartId = 1, Status = CartStatus.Active, CustomerId = 1 },
                new Cart() { CartId = 2, Status = CartStatus.Bought, CustomerId = 2 },
                new Cart() { CartId = 3, Status = CartStatus.Abandoned, CustomerId = 3 }
                );

            //seed value for cartitem
            db.CartItems.AddOrUpdate(x => x.CartItemId,
                new CartItem() { CartItemId = 1, ProductId = 1, Quantity = 2, CartId = 1 },
                new CartItem() { CartItemId = 2, ProductId = 2, Quantity = 3, CartId = 1 },
                new CartItem() { CartItemId = 3, ProductId = 3, Quantity = 1, CartId = 2 },
                new CartItem() { CartItemId = 4, ProductId = 2, Quantity = 4, CartId = 2 },
                new CartItem() { CartItemId = 5, ProductId = 1, Quantity = 1, CartId = 3 },
                new CartItem() { CartItemId = 6, ProductId = 2, Quantity = 5, CartId = 3 },
                new CartItem() { CartItemId = 7, ProductId = 3, Quantity = 2, CartId = 3 }
                );
        }
    }
}
