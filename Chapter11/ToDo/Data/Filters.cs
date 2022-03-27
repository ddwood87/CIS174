using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Data
{
    public class Filters
    {
        public Filters(string filterstring)
        {
            filterstring = filterstring ?? "all-all-all-all-all";
            FilterString = filterstring;
            string[] filters = filterstring.Split('-');
            if(filters[0] == "all") { SprintId = -2; }
            else { SprintId = int.Parse(filters[0]); }
            if(filters[1] == "all") { MinPoints = -2; }
            else { MinPoints = int.Parse(filters[1]); }
            if(filters[2] == "all") { MaxPoints = -2; }
            else { MaxPoints = int.Parse(filters[2]); }
            Due = filters[3];
            StatusId = filters[4];
        }
        public string FilterString { get; }
        public int SprintId { get; }
        public int MinPoints { get; }
        public int MaxPoints { get; }
        public string Due { get; }
        public string StatusId { get; }

        public bool HasSprint => SprintId != -2;
        public bool HasMinPoints => MinPoints != -2;
        public bool HasMaxPoints => MaxPoints != -2;
        public bool HasDue => Due.ToLower() != "all";
        public bool HasStatus => StatusId.ToLower() != "all";

        public static Dictionary<string, string> DueFilterValues =>
            new Dictionary<string, string> {
                {"future", "Future"},
                {"past", "Past"},
                {"today", "Today"}
            };
        public bool IsPast => Due.ToLower() == "past";
        public bool IsFuture => Due.ToLower() == "future";
        public bool IsToday => Due.ToLower() == "today";
    }
}
