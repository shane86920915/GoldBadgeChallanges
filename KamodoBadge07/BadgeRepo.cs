using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamodoBadge07
{
    public  class BadgeRepo
    {
        private readonly Dictionary<int, Badge> _badges = new Dictionary<int, Badge>();
        int Count;


        public void CreateBadge(Badge badge)
        {
            Count++;
            _badges.Add(Count, badge);
        }

        public Dictionary<int, Badge> GetBadges()
        {
            return _badges;
        }

        public bool EditBadge(int dictkey, Badge badge)
        {
            Badge badge1 = GetBadgeByKey(dictkey);
            if (badge1 != null)
            {
                badge1.BadgeID = badge.BadgeID;
                badge1.DoorNames = badge1.DoorNames;
                return true;
            }
            return false;
        }

        public Badge GetBadgeByKey(int dictKey)
        {
            foreach (var pair in _badges)
            {
                if (pair.Key == dictKey)
                {
                    return pair.Value;
                }
            }
            return null;
        }

        public bool RemoveADoor(int dictKey, string doorName)
        {
            Badge badge = GetBadgeByKey(dictKey);
            if (badge == null)
            {
                return false;
            }
            foreach (var door in badge.DoorNames)
            {
                if (door == doorName)
                {
                    badge.DoorNames.Remove(door);
                    return true;
                }
            }
            return false;
        }

        public bool AddADoor(int dictKey, string doorName)
        {
            Badge badge = GetBadgeByKey(dictKey);
            if (badge == null)
            {
                return false;
            }
            badge.DoorNames.Add(doorName);
            return true;

        }
    }

}
