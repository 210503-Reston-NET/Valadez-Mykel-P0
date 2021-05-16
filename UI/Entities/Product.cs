using System;
using System.Collections.Generic;

#nullable disable

namespace UI.Entities
{
    public partial class Product
    {
        public Product()
        {
            LocationProductInventories = new HashSet<LocationProductInventory>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public virtual ICollection<LocationProductInventory> LocationProductInventories { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
