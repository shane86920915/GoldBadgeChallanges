using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamodoBadge07
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> DoorNames { get; set; } = new List<string>();

        public Badge()
        {

        }
        public Badge(int badgeid, List<string> doornames)
        {
            BadgeID = badgeid;
            DoorNames = doornames;
         
        }

    }
}
