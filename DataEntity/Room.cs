using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class Room
    {
        public int Id { get; set; }
        public int VenueId { get; set; }

        public string Name { get; set; } = null!;
        public string Feature { get; set; } = null!;
        public decimal BaseHourlyRate { get; set; }

        public RoomStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool InActive { get; set; }
    }
    public enum RoomStatus
    {
        Available = 0,
        Occupied = 1,
        NeedsCleaning = 2,
        Cleaning = 3
    }

}
