using System.Collections.Generic;

namespace Com.CompanyName.OnlineShop.ComponentLibrary.Entity
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }

        public ICollection<Cart> Carts { get; set; }
    }
}
