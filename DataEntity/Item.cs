using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class Item
    {
        public int Id { get; set; }
        public int VenueId { get; set; }

        public string Name { get; set; } = null!;
        public ItemType Type { get; set; }

        public decimal Price { get; set; }
        public bool InActive { get; set; }
    }
    public enum ItemType
    {
        Inventory = 0,
        Service = 1,
        TimeCharge = 2,
        Discount = 3
    }

}
