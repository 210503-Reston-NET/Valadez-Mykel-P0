using System;
using System.Collections.Generic;

#nullable disable

namespace DataLogic.Entities
{
    public partial class LocationProductInventory
    {
        public int InventoryId { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }
        public virtual Product Product { get; set; }
    }
}
