using Com.CompanyName.OnlineShop.ComponentLibrary.Types;
using System.Collections.Generic;

namespace Com.CompanyName.OnlineShop.ComponentLibrary.Entity
{
    public class Cart
    {
        public int CartId { get; set; }
        public CartStatus Status { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
