using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class Venue
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public string Phone { get; set; } = null!;
    }

}
