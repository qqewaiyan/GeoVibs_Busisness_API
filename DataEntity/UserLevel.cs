using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class UserLevel
    {
        public int Id { get; set; }
        public int VenueId { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool CanManageRoom { get; set; }
        public bool CanManageSession { get; set; }
    }

}
