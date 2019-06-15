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
        [Column(TypeName = "varchar")]
        [RegularExpression(@"^[a-z A-Z]+$", ErrorMessage = "Use alphabets only please")]
        public string Name { get; set; }

        [EmailAddress]
        [StringLength(256)]
        [Column(TypeName = "varchar")]
        public string Email { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar")]
        public string Password { get; set; }

        [StringLength(100)]
        [Column(TypeName = "varchar")]
        public string Address { get; set; }

        public ICollection<Cart> Carts { get; set; }
    }
}
