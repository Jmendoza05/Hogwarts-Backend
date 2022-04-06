using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HogwartsBackend.Data;
using HogwartsBackend.Models;

namespace HogwartsBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class aspirantesController : Controller
    {
        private readonly HogwartsBackendContext _context;

        public aspirantesController(HogwartsBackendContext context)
        {
            _context = context;
        }

        // GET: aspirantes
        public async Task<IActionResult> Index()
        {
            return View(await _context.aspirante.ToListAsync());
        }

        // GET: aspirantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspirante = await _context.aspirante
                .FirstOrDefaultAsync(m => m.id == id);
            if (aspirante == null)
            {
                return NotFound();
            }

            return View(aspirante);
        }

        // GET: aspirantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: aspirantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,apellidos,identificacion,edad,casa")] aspirante aspirante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aspirante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aspirante);
        }

        // GET: aspirantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspirante = await _context.aspirante.FindAsync(id);
            if (aspirante == null)
            {
                return NotFound();
            }
            return View(aspirante);
        }

        // POST: aspirantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,apellidos,identificacion,edad,casa")] aspirante aspirante)
        {
            if (id != aspirante.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aspirante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!aspiranteExists(aspirante.id))
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
            return View(aspirante);
        }

        // GET: aspirantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspirante = await _context.aspirante
                .FirstOrDefaultAsync(m => m.id == id);
            if (aspirante == null)
            {
                return NotFound();
            }

            return View(aspirante);
        }

        // POST: aspirantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aspirante = await _context.aspirante.FindAsync(id);
            _context.aspirante.Remove(aspirante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool aspiranteExists(int id)
        {
            return _context.aspirante.Any(e => e.id == id);
        }
    }
}
