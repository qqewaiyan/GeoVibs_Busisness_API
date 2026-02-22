using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class IdParam
    {
        public int VenueId { get; set; }
        public int Id { get; set; }
    }
    public class SessionDateParam
    {
        public int VenueId { get; set;  }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
    public class VenueParam
    {
        public int VenueId { get; set; }
    }
    public class RegisterRequestParam
    {
        public string VenueName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string VenueType { get; set; } = string.Empty;
    }

    public class LoginRequestParam
    {
        public string PhoneNumber {  get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class LoginInfo
    {
        public bool IsSuccess { get; set; }
        public string Token { get; set; } = string.Empty;
        public Venue? CurrentVenue { get; set; }
    }
}
