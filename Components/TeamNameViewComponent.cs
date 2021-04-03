using BowlingLeagueInfo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeagueInfo.Components
{
    public class TeamNameViewComponent : ViewComponent
    {
        private BowlingLeagueContext _context;
        public TeamNameViewComponent (BowlingLeagueContext context)
        {
            _context = context;
        }

        //invoke component result
        public IViewComponentResult Invoke()
        {
            //set viewbag selected type to teamname from routing data
            ViewBag.SelectedType = RouteData?.Values["teamname"];
            //return component view with team objects
            return View(_context.Teams
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
