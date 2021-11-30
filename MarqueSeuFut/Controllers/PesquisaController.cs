using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MarqueSeuFut.Models;
namespace MarqueSeuFut.Controllers
{
    public class PesquisaController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PesquisaController(ApplicationDbContext context)
        {
            _context = context;
        }

        

        public async Task<IActionResult> Index()
        {
            return View(await _context.Times.ToListAsync());
        }

        // GET: Times/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var time = await _context.Times
                .FirstOrDefaultAsync(m => m.Id == id);
            if (time == null)
            {
                return NotFound();
            }

            return View(time);
        }
    }
}


    
