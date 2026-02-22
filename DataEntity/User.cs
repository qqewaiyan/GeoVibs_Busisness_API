using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class User
    {
        public int Id { get; set; }
        public int VenueId { get; set; }
        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;

        public int UserLevelId { get; set; }
        public bool InActive { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
