using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.CompanyName.OnlineShop.ComponentLibrary.Entity
{

    public class Product
    {
        public Product()
        {

        }

        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        [RegularExpression(@"^[a-z A-Z]+$", ErrorMessage = "Use alphabets only please")]
        public string Name { get; set; }

        [StringLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Description { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
