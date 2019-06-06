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
        [Column(TypeName = "varchar(50)")]
        public string CategoryName { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string SubCategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
