using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeagueInfo.Models.ViewModels
{
    public class IndexViewModel
    {
        //View model for Index View.  Consolidates information/classes to be used in View
        public List<Bowlers> Bowlers { get; set; }
        public PageNumberingInfo PageNumberingInfo { get; set; }
        public string TeamName { get; set; }
    }
}
