
using BB207_Mamba.ViewModels;
using Business.Services.Abstrcats;
using Core.Models;
using Data.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BB207_Mamba.Controllers
{
    public class HomeController : Controller
    {
        ITeamService _teamService;

        public HomeController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IActionResult Index()
        {
            List<Team> teams = _teamService.GetAllTeams();
            return View(teams);
        }


      

    }
}