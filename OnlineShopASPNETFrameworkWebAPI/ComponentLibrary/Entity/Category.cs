﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public ICollection<Product> Products  { get; set; }
    }
}
