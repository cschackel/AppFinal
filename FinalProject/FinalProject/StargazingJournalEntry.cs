using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject
{
    public class StargazingJournalEntry
    {
        [PrimaryKey, AutoIncrement]
        public int JournalID { get; set; }

        public DateTime Time { get; set; }

        public double? Lat { get; set; }

        public double? Long { get; set; }

        public String SkyConditions { get; set; }

        public double TelescopeMagnification { get; set; }

        public String TelescopeType { get; set; }

        public String StellarObject { get; set; }

        public double? PositionAngle { get; set; }

    }
}
