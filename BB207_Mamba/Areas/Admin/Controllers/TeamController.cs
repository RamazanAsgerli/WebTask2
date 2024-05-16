using Business.Services.Abstrcats;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BB207_Mamba.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IActionResult Index()
        {
            List<Team>teams = _teamService.GetAllTeams();
            return View(teams);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(Team team)
        {
            if(!ModelState.IsValid) return View();
            _teamService.AddTeam(team);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _teamService.RemoveTeam(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            Team team = _teamService.GetTeam(x => x.Id == id);
            return View(team);

        }
        [HttpPost]
        public IActionResult Update(Team team)
        {
            _teamService.UpdateTeam(team.Id, team);
            return RedirectToAction(nameof(Index));
        }
    }
}
