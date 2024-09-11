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
    public class FrequenciaVacinaController : Controller
    {
        private readonly Contexto _context;

        public FrequenciaVacinaController(Contexto context)
        {
            _context = context;
        }

        // GET: FrequenciaVacina
        public async Task<IActionResult> Index()
        {
              return _context.FrequenciaVacina != null ? 
                          View(await _context.FrequenciaVacina.ToListAsync()) :
                          Problem("Entity set 'Contexto.FrequenciaVacina'  is null.");
        }

        // GET: FrequenciaVacina/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FrequenciaVacina == null)
            {
                return NotFound();
            }

            var frequenciaVacina = await _context.FrequenciaVacina
                .FirstOrDefaultAsync(m => m.FrequenciaVacinaId == id);
            if (frequenciaVacina == null)
            {
                return NotFound();
            }

            return View(frequenciaVacina);
        }

        // GET: FrequenciaVacina/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FrequenciaVacina/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FrequenciaVacinaId,FrequenciaVacinaDescricao")] FrequenciaVacina frequenciaVacina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(frequenciaVacina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(frequenciaVacina);
        }

        // GET: FrequenciaVacina/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FrequenciaVacina == null)
            {
                return NotFound();
            }

            var frequenciaVacina = await _context.FrequenciaVacina.FindAsync(id);
            if (frequenciaVacina == null)
            {
                return NotFound();
            }
            return View(frequenciaVacina);
        }

        // POST: FrequenciaVacina/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FrequenciaVacinaId,FrequenciaVacinaDescricao")] FrequenciaVacina frequenciaVacina)
        {
            if (id != frequenciaVacina.FrequenciaVacinaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(frequenciaVacina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FrequenciaVacinaExists(frequenciaVacina.FrequenciaVacinaId))
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
            return View(frequenciaVacina);
        }

        // GET: FrequenciaVacina/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FrequenciaVacina == null)
            {
                return NotFound();
            }

            var frequenciaVacina = await _context.FrequenciaVacina
                .FirstOrDefaultAsync(m => m.FrequenciaVacinaId == id);
            if (frequenciaVacina == null)
            {
                return NotFound();
            }

            return View(frequenciaVacina);
        }

        // POST: FrequenciaVacina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FrequenciaVacina == null)
            {
                return Problem("Entity set 'Contexto.FrequenciaVacina'  is null.");
            }
            var frequenciaVacina = await _context.FrequenciaVacina.FindAsync(id);
            if (frequenciaVacina != null)
            {
                _context.FrequenciaVacina.Remove(frequenciaVacina);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FrequenciaVacinaExists(int id)
        {
          return (_context.FrequenciaVacina?.Any(e => e.FrequenciaVacinaId == id)).GetValueOrDefault();
        }
    }
}
