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
    public class PartidasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PartidasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Partidas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Partidas.Include(p => p.TimeCasa).Include(p => p.TimeVisitante);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Partidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partida = await _context.Partidas
                .Include(p => p.TimeCasa)
                .Include(p => p.TimeVisitante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partida == null)
            {
                return NotFound();
            }

            return View(partida);
        }

        // GET: Partidas/Create
        public IActionResult Create()
        {
            ViewData["TimeCasaId"] = new SelectList(_context.Times, "Id", "Nome");
            ViewData["TimeVisitanteId"] = new SelectList(_context.Times, "Id", "Nome");
            return View();
        }

        // POST: Partidas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Data,Quadra,Cidade,TimeCasaId,TimeVisitanteId")] Partida partida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TimeCasaId"] = new SelectList(_context.Times, "Id", "Nome", partida.TimeCasaId);
            ViewData["TimeVisitanteId"] = new SelectList(_context.Times, "Id", "Nome", partida.TimeVisitanteId);
            return View(partida);
        }

        // GET: Partidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partida = await _context.Partidas.FindAsync(id);
            if (partida == null)
            {
                return NotFound();
            }
            ViewData["TimeCasaId"] = new SelectList(_context.Times, "Id", "Nome", partida.TimeCasaId);
            ViewData["TimeVisitanteId"] = new SelectList(_context.Times, "Id", "Nome", partida.TimeVisitanteId);
            return View(partida);
        }

        // POST: Partidas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Data,Quadra,Cidade,TimeCasaId,TimeVisitanteId")] Partida partida)
        {
            if (id != partida.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartidaExists(partida.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TimeCasaId"] = new SelectList(_context.Times, "Id", "Nome", partida.TimeCasaId);
            ViewData["TimeVisitanteId"] = new SelectList(_context.Times, "Id", "Nome", partida.TimeVisitanteId);
            return View(partida);
        }

        // GET: Partidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partida = await _context.Partidas
                .Include(p => p.TimeCasa)
                .Include(p => p.TimeVisitante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partida == null)
            {
                return NotFound();
            }

            return View(partida);
        }

        // POST: Partidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partida = await _context.Partidas.FindAsync(id);
            _context.Partidas.Remove(partida);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartidaExists(int id)
        {
            return _context.Partidas.Any(e => e.Id == id);
        }
    }
}
