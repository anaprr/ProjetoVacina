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
    public class IndicacaoIdadeController : Controller
    {
        private readonly Contexto _context;

        public IndicacaoIdadeController(Contexto context)
        {
            _context = context;
        }

        // GET: IndicacaoIdade
        public async Task<IActionResult> Index()
        {
              return _context.IndicacaoIdade != null ? 
                          View(await _context.IndicacaoIdade.ToListAsync()) :
                          Problem("Entity set 'Contexto.IndicacaoIdade'  is null.");
        }

        // GET: IndicacaoIdade/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.IndicacaoIdade == null)
            {
                return NotFound();
            }

            var indicacaoIdade = await _context.IndicacaoIdade
                .FirstOrDefaultAsync(m => m.IndicacaoIdadeId == id);
            if (indicacaoIdade == null)
            {
                return NotFound();
            }

            return View(indicacaoIdade);
        }

        // GET: IndicacaoIdade/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IndicacaoIdade/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IndicacaoIdadeId,IndicacaoIdadeDescricao")] IndicacaoIdade indicacaoIdade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(indicacaoIdade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(indicacaoIdade);
        }

        // GET: IndicacaoIdade/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.IndicacaoIdade == null)
            {
                return NotFound();
            }

            var indicacaoIdade = await _context.IndicacaoIdade.FindAsync(id);
            if (indicacaoIdade == null)
            {
                return NotFound();
            }
            return View(indicacaoIdade);
        }

        // POST: IndicacaoIdade/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IndicacaoIdadeId,IndicacaoIdadeDescricao")] IndicacaoIdade indicacaoIdade)
        {
            if (id != indicacaoIdade.IndicacaoIdadeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(indicacaoIdade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IndicacaoIdadeExists(indicacaoIdade.IndicacaoIdadeId))
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
            return View(indicacaoIdade);
        }

        // GET: IndicacaoIdade/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.IndicacaoIdade == null)
            {
                return NotFound();
            }

            var indicacaoIdade = await _context.IndicacaoIdade
                .FirstOrDefaultAsync(m => m.IndicacaoIdadeId == id);
            if (indicacaoIdade == null)
            {
                return NotFound();
            }

            return View(indicacaoIdade);
        }

        // POST: IndicacaoIdade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.IndicacaoIdade == null)
            {
                return Problem("Entity set 'Contexto.IndicacaoIdade'  is null.");
            }
            var indicacaoIdade = await _context.IndicacaoIdade.FindAsync(id);
            if (indicacaoIdade != null)
            {
                _context.IndicacaoIdade.Remove(indicacaoIdade);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IndicacaoIdadeExists(int id)
        {
          return (_context.IndicacaoIdade?.Any(e => e.IndicacaoIdadeId == id)).GetValueOrDefault();
        }
    }
}
