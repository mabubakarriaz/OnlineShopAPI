using Com.CompanyName.OnlineShop.ComponentLibrary.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.CompanyName.OnlineShop.ComponentLibrary.Entity
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public CartStatus Status { get; set; }

        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
