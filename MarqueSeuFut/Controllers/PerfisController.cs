using MarqueSeuFut.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MarqueSeuFut.Controllers
{
    public class PerfisController : Controller
    {
        private readonly ILogger<PerfisController> _logger;
        private readonly ApplicationDbContext _context;

        public PerfisController(ILogger<PerfisController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Times = _context.Times.Where(d => d.Id == 1).ToList();
            ViewBag.Estatisticas = _context.Estatistica.Where(d => d.PartidaId == 1).ToList();
            ViewBag.Partidas = _context.Partidas.Where(d => d.Id == 1).ToList();
            ViewBag.Escalacao = _context.Escalacoes.Where(d => d.IsTItular == true).ToList();
            ViewBag.Jogadores = _context.Jogadores.Select(d => d.Id).ToList();
            

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
