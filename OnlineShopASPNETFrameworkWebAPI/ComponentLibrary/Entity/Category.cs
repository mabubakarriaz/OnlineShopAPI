using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Com.CompanyName.OnlineShop.ComponentLibrary.Entity
{
    public class Category
    {
        public Category()
        {

        }

        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
