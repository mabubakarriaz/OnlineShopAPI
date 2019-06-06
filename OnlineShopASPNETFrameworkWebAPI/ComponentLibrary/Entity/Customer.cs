using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.CompanyName.OnlineShop.ComponentLibrary.Entity
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }

        [StringLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Address { get; set; }

        public ICollection<Cart> Carts { get; set; }
    }
}
