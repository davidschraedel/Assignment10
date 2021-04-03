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


        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["teamname"];

            return View(_context.Teams
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
