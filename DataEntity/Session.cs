using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class Session
    {
        public int Id { get; set; }
        public int VenueId { get; set; }

        public int RoomId { get; set; }
        public int MovieId { get; set; }

        public DateTime StartAt { get; set; }
        public DateTime ExpectedEndAt { get; set; }
        public DateTime? EndAt { get; set; }

        public decimal RoomCharge { get; set; }
        public decimal ExtraCharge { get; set; }
        public decimal Total { get; set; }

        public SessionStatus Status { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    public enum SessionStatus
    {
        Active = 0,
        Finished = 1,
        Cancelled = 2
    }
    public class SessionPreviewRequest
    {
        public int VenueId { get; set; }
        public int RoomId { get; set; }
        public int MovieId { get; set; }
        public DateTime StartAt { get; set; }
        public decimal ExtraCharge { get; set; }
    }
    public class SessionPreviewResponse
    {
        public DateTime ExpectedEndAt { get; set; }
        public int DurationMinutes { get; set; }
        public int HoursCharged { get; set; }
        public decimal RoomCharge { get; set; }
        public decimal Total { get; set; }
    }


}
