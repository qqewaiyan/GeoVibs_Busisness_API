using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class SessionDetail
    {
        public int Id { get; set; }
        public int VenueId { get; set; }
        public int SessionId { get; set; }

        public int? ItemId { get; set; }

        public string Name { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public int Qty { get; set; }

        public decimal Total { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
