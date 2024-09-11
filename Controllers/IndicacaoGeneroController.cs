using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoVacina.Models;

namespace ProjetoVacina.Controllers
{
    public class IndicacaoGeneroController : Controller
    {
        private readonly Contexto _context;

        public IndicacaoGeneroController(Contexto context)
        {
            _context = context;
        }

        // GET: IndicacaoGenero
        public async Task<IActionResult> Index()
        {
              return _context.IndicacaoGenero != null ? 
                          View(await _context.IndicacaoGenero.ToListAsync()) :
                          Problem("Entity set 'Contexto.IndicacaoGenero'  is null.");
        }

        // GET: IndicacaoGenero/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.IndicacaoGenero == null)
            {
                return NotFound();
            }

            var indicacaoGenero = await _context.IndicacaoGenero
                .FirstOrDefaultAsync(m => m.IndicacaoGeneroId == id);
            if (indicacaoGenero == null)
            {
                return NotFound();
            }

            return View(indicacaoGenero);
        }

        // GET: IndicacaoGenero/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IndicacaoGenero/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IndicacaoGeneroId,IndicacaoGeneroDescricao")] IndicacaoGenero indicacaoGenero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(indicacaoGenero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(indicacaoGenero);
        }

        // GET: IndicacaoGenero/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.IndicacaoGenero == null)
            {
                return NotFound();
            }

            var indicacaoGenero = await _context.IndicacaoGenero.FindAsync(id);
            if (indicacaoGenero == null)
            {
                return NotFound();
            }
            return View(indicacaoGenero);
        }

        // POST: IndicacaoGenero/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IndicacaoGeneroId,IndicacaoGeneroDescricao")] IndicacaoGenero indicacaoGenero)
        {
            if (id != indicacaoGenero.IndicacaoGeneroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(indicacaoGenero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IndicacaoGeneroExists(indicacaoGenero.IndicacaoGeneroId))
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
            return View(indicacaoGenero);
        }

        // GET: IndicacaoGenero/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.IndicacaoGenero == null)
            {
                return NotFound();
            }

            var indicacaoGenero = await _context.IndicacaoGenero
                .FirstOrDefaultAsync(m => m.IndicacaoGeneroId == id);
            if (indicacaoGenero == null)
            {
                return NotFound();
            }

            return View(indicacaoGenero);
        }

        // POST: IndicacaoGenero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.IndicacaoGenero == null)
            {
                return Problem("Entity set 'Contexto.IndicacaoGenero'  is null.");
            }
            var indicacaoGenero = await _context.IndicacaoGenero.FindAsync(id);
            if (indicacaoGenero != null)
            {
                _context.IndicacaoGenero.Remove(indicacaoGenero);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IndicacaoGeneroExists(int id)
        {
          return (_context.IndicacaoGenero?.Any(e => e.IndicacaoGeneroId == id)).GetValueOrDefault();
        }
    }
}
