using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FairlyRandom.Models
{
    public class RankedAttendeeViewModel
    {
        public int BestRankToShow { get; set; }
        public int WorstRankToShow { get; set; }
        public List<RankedAttendee> RankedAttendees { get; set; }

        public RankedAttendeeViewModel()
        {
            BestRankToShow = Convert.ToInt32(ConfigurationManager.AppSettings.Get("BestRankToShow"));
            WorstRankToShow = Convert.ToInt32(ConfigurationManager.AppSettings.Get("WorstRankToShow"));
            RankedAttendees = new List<RankedAttendee>();
        }

        public RankedAttendeeViewModel(List<RankedAttendee> rankedAttendees)
        {
            BestRankToShow = Convert.ToInt32(ConfigurationManager.AppSettings.Get("BestRankToShow"));
            WorstRankToShow = Convert.ToInt32(ConfigurationManager.AppSettings.Get("WorstRankToShow"));
            RankedAttendees = rankedAttendees;
        }
    }
}