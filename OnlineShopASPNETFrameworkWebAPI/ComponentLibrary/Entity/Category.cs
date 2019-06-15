using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.CompanyName.OnlineShop.ComponentLibrary.Entity
{
    public class Category
    {
        public Category()
        {

        }

        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        [RegularExpression(@"^[a-z A-Z]+$", ErrorMessage = "Use alphabets only please")]
        public string CategoryName { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        [RegularExpression(@"^[a-z A-Z]+$", ErrorMessage = "Use alphabets only please")]
        public string SubCategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
