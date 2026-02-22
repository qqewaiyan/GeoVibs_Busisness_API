using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class Movie
    {
        public int Id { get; set; }
        public int VenueId { get; set; }

        public string Title { get; set; } = null!;
        public int DurationMinutes { get; set; }

        public bool InActive { get; set; }
    }

}
