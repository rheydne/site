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
    public class JogadoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JogadoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Jogadores
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Jogadores.Include(j => j.Posicao).Include(j => j.Time);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Jogadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogador = await _context.Jogadores
                .Include(j => j.Posicao)
                .Include(j => j.Time)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jogador == null)
            {
                return NotFound();
            }

            return View(jogador);
        }

        // GET: Jogadores/Create
        public IActionResult Create()
        {
            ViewData["PosicaoId"] = new SelectList(_context.Posicoes, "Id", "Nome");
            ViewData["TimeId"] = new SelectList(_context.Times, "Id", "Nome");
            return View();
        }

        // POST: Jogadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Numero,PosicaoId,TimeId")] Jogador jogador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jogador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PosicaoId"] = new SelectList(_context.Posicoes, "Id", "Nome", jogador.PosicaoId);
            ViewData["TimeId"] = new SelectList(_context.Times, "Id", "Nome", jogador.TimeId);
            return View(jogador);
        }

        // GET: Jogadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogador = await _context.Jogadores.FindAsync(id);
            if (jogador == null)
            {
                return NotFound();
            }
            ViewData["PosicaoId"] = new SelectList(_context.Posicoes, "Id", "Nome", jogador.PosicaoId);
            ViewData["TimeId"] = new SelectList(_context.Times, "Id", "Nome", jogador.TimeId);
            return View(jogador);
        }

        // POST: Jogadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Numero,PosicaoId,TimeId")] Jogador jogador)
        {
            if (id != jogador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jogador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JogadorExists(jogador.Id))
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
            ViewData["PosicaoId"] = new SelectList(_context.Posicoes, "Id", "Nome", jogador.PosicaoId);
            ViewData["TimeId"] = new SelectList(_context.Times, "Id", "Nome", jogador.TimeId);
            return View(jogador);
        }

        // GET: Jogadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogador = await _context.Jogadores
                .Include(j => j.Posicao)
                .Include(j => j.Time)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jogador == null)
            {
                return NotFound();
            }

            return View(jogador);
        }

        // POST: Jogadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var escalacao = await _context.Escalacoes.FindAsync(id);
            if(escalacao != null)
            {
                _context.Escalacoes.Remove(escalacao);
            }
            var jogador = await _context.Jogadores.FindAsync(id);
            _context.Jogadores.Remove(jogador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JogadorExists(int id)
        {
            return _context.Jogadores.Any(e => e.Id == id);
        }
    }
}
