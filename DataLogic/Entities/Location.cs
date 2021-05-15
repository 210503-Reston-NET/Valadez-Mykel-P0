using System;
using System.Collections.Generic;

#nullable disable

namespace DataLogic.Entities
{
    public partial class Location
    {
        public Location()
        {
            LocationProductInventories = new HashSet<LocationProductInventory>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<LocationProductInventory> LocationProductInventories { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
