using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MinhaDemoMVC_2.Data;
using MinhaDemoMVC_2.Models;

namespace MinhaDemoMVC_2.Controllers.FilmesScaffold
{
    public class FilmeScaffoldsController : Controller
    {
        private readonly MinhaDemoMVC_2Context _context;

        public FilmeScaffoldsController(MinhaDemoMVC_2Context context)
        {
            _context = context;
        }

        // GET: FilmeScaffolds
        public async Task<IActionResult> Index()
        {
            return View(await _context.FilmeScaffold.ToListAsync());
        }

        // GET: FilmeScaffolds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmeScaffold = await _context.FilmeScaffold
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filmeScaffold == null)
            {
                return NotFound();
            }

            return View(filmeScaffold);
        }

        // GET: FilmeScaffolds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FilmeScaffolds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,DataLancamento,Genero,Valor,Avaliacao")] FilmeScaffold filmeScaffold)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filmeScaffold);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filmeScaffold);
        }

        // GET: FilmeScaffolds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmeScaffold = await _context.FilmeScaffold.FindAsync(id);
            if (filmeScaffold == null)
            {
                return NotFound();
            }
            return View(filmeScaffold);
        }

        // POST: FilmeScaffolds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,DataLancamento,Genero,Valor,Avaliacao")] FilmeScaffold filmeScaffold)
        {
            if (id != filmeScaffold.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmeScaffold);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmeScaffoldExists(filmeScaffold.Id))
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
            return View(filmeScaffold);
        }

        // GET: FilmeScaffolds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmeScaffold = await _context.FilmeScaffold
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filmeScaffold == null)
            {
                return NotFound();
            }

            return View(filmeScaffold);
        }

        // POST: FilmeScaffolds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filmeScaffold = await _context.FilmeScaffold.FindAsync(id);
            _context.FilmeScaffold.Remove(filmeScaffold);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmeScaffoldExists(int id)
        {
            return _context.FilmeScaffold.Any(e => e.Id == id);
        }
    }
}
