﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.CompanyName.OnlineShop.ComponentLibrary.Entity
{
    public class Product
    {
        public Product()
        {

        }


        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
