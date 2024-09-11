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
    public class VacinaController : Controller
    {
        private readonly Contexto _context;

        public VacinaController(Contexto context)
        {
            _context = context;
        }

        // GET: Vacina
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Vacina.Include(v => v.IndicacaoGenero).Include(v => v.IndicacaoIdade);
            return View(await contexto.ToListAsync());
        }

        // GET: Vacina/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vacina == null)
            {
                return NotFound();
            }

            var vacina = await _context.Vacina
                .Include(v => v.IndicacaoGenero)
                .Include(v => v.IndicacaoIdade)
                .FirstOrDefaultAsync(m => m.VacinaId == id);
            if (vacina == null)
            {
                return NotFound();
            }

            return View(vacina);
        }

        // GET: Vacina/Create
        public IActionResult Create()
        {
            ViewData["IndicacaoGeneroId"] = new SelectList(_context.IndicacaoGenero, "IndicacaoGeneroId", "IndicacaoGeneroDescricao");
            ViewData["IndicacaoIdadeId"] = new SelectList(_context.IndicacaoIdade, "IndicacaoIdadeId", "IndicacaoIdadeDescricao");
            return View();
        }

        // POST: Vacina/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VacinaId,VacinaNome,VacinaDescricao,IndicacaoGeneroId,IndicacaoIdadeId")] Vacina vacina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vacina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IndicacaoGeneroId"] = new SelectList(_context.IndicacaoGenero, "IndicacaoGeneroId", "IndicacaoGeneroDescricao", vacina.IndicacaoGeneroId);
            ViewData["IndicacaoIdadeId"] = new SelectList(_context.IndicacaoIdade, "IndicacaoIdadeId", "IndicacaoIdadeDescricao", vacina.IndicacaoIdadeId);
            return View(vacina);
        }

        // GET: Vacina/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vacina == null)
            {
                return NotFound();
            }

            var vacina = await _context.Vacina.FindAsync(id);
            if (vacina == null)
            {
                return NotFound();
            }
            ViewData["IndicacaoGeneroId"] = new SelectList(_context.IndicacaoGenero, "IndicacaoGeneroId", "IndicacaoGeneroDescricao", vacina.IndicacaoGeneroId);
            ViewData["IndicacaoIdadeId"] = new SelectList(_context.IndicacaoIdade, "IndicacaoIdadeId", "IndicacaoIdadeDescricao", vacina.IndicacaoIdadeId);
            return View(vacina);
        }

        // POST: Vacina/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VacinaId,VacinaNome,VacinaDescricao,IndicacaoGeneroId,IndicacaoIdadeId")] Vacina vacina)
        {
            if (id != vacina.VacinaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacinaExists(vacina.VacinaId))
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
            ViewData["IndicacaoGeneroId"] = new SelectList(_context.IndicacaoGenero, "IndicacaoGeneroId", "IndicacaoGeneroDescricao", vacina.IndicacaoGeneroId);
            ViewData["IndicacaoIdadeId"] = new SelectList(_context.IndicacaoIdade, "IndicacaoIdadeId", "IndicacaoIdadeDescricao", vacina.IndicacaoIdadeId);
            return View(vacina);
        }

        // GET: Vacina/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vacina == null)
            {
                return NotFound();
            }

            var vacina = await _context.Vacina
                .Include(v => v.IndicacaoGenero)
                .Include(v => v.IndicacaoIdade)
                .FirstOrDefaultAsync(m => m.VacinaId == id);
            if (vacina == null)
            {
                return NotFound();
            }

            return View(vacina);
        }

        // POST: Vacina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vacina == null)
            {
                return Problem("Entity set 'Contexto.Vacina'  is null.");
            }
            var vacina = await _context.Vacina.FindAsync(id);
            if (vacina != null)
            {
                _context.Vacina.Remove(vacina);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacinaExists(int id)
        {
          return (_context.Vacina?.Any(e => e.VacinaId == id)).GetValueOrDefault();
        }
    }
}
