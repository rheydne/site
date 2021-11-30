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
    public class PosicoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PosicoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Posicoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Posicoes.ToListAsync()); //select * from generos
        }

        // GET: Posicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posicao = await _context.Posicoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (posicao == null)
            {
                return NotFound();
            }

            return View(posicao);
        }

        // GET: Posicoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Posicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Posicao posicao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(posicao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(posicao);
        }

        // GET: Posicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posicao = await _context.Posicoes.FindAsync(id);
            if (posicao == null)
            {
                return NotFound();
            }
            return View(posicao);
        }

        // POST: Posicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Posicao posicao)
        {
            if (id != posicao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(posicao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PosicaoExists(posicao.Id))
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
            return View(posicao);
        }

        // GET: Posicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posicao = await _context.Posicoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (posicao == null)
            {
                return NotFound();
            }

            return View(posicao);
        }

        // POST: Posicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var posicao = await _context.Posicoes.FindAsync(id);
            _context.Posicoes.Remove(posicao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PosicaoExists(int id)
        {
            return _context.Posicoes.Any(e => e.Id == id);
        }
    }
}
