using System.Collections.Generic;

namespace Com.CompanyName.OnlineShop.ComponentLibrary.Entity
{
    public class Category
    {
        public Category()
        {

        }

        public int CategoryId { get; set; }
        public int MyProperty { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
