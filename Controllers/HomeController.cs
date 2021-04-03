using BowlingLeagueInfo.Models;
using BowlingLeagueInfo.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeagueInfo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext _context { get; set; }

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(long? teamid, string teamname, int pageNum = 0)
        {
            //initialize page size to 5 items
            int pageSize = 5;

            //return view with IndexViewModel object
            return View(new IndexViewModel
            {
                //bowler objects for the team selected, or all bowlers if no team is selected, ordered by bowlers' last name
                Bowlers = (_context.Bowlers
                .Where(x => x.Team.TeamId == teamid || teamid == null)
                .OrderBy(x => x.BowlerLastName)
                .Skip((pageNum - 1) * pageSize) //skip according to which page is selected
                .Take(pageSize) //take the number of items determined by pageSize variable
                .ToList()),

                //page number information object
                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    //if no team is selected, get full count of Bowlers. Otherwise, count number of bowlers on selected team
                    TotalNumItems = (teamid == null ? _context.Bowlers.Count() :
                        _context.Bowlers.Where(x => x.Team.TeamId == teamid).Count())
                },
                //name of team selected
                TeamName = teamname
            });
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
