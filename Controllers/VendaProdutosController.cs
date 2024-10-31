using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EletronicosRuiz.Data;
using EletronicosRuiz.Models;

namespace EletronicosRuiz.Controllers
{
    public class VendaProdutosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VendaProdutosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VendaProdutos
        public async Task<IActionResult> Index()
        {
            return View(await _context.VendaProduto.ToListAsync());
        }

        // GET: VendaProdutos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendaProduto = await _context.VendaProduto
                .FirstOrDefaultAsync(m => m.Quantidade == id);
            if (vendaProduto == null)
            {
                return NotFound();
            }

            return View(vendaProduto);
        }

        // GET: VendaProdutos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VendaProdutos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Quantidade,VendaId,ProdutoId")] VendaProduto vendaProduto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendaProduto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vendaProduto);
        }

        // GET: VendaProdutos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendaProduto = await _context.VendaProduto.FindAsync(id);
            if (vendaProduto == null)
            {
                return NotFound();
            }
            return View(vendaProduto);
        }

        // POST: VendaProdutos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Quantidade,VendaId,ProdutoId")] VendaProduto vendaProduto)
        {
            if (id != vendaProduto.Quantidade)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendaProduto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaProdutoExists(vendaProduto.Quantidade))
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
            return View(vendaProduto);
        }

        // GET: VendaProdutos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendaProduto = await _context.VendaProduto
                .FirstOrDefaultAsync(m => m.Quantidade == id);
            if (vendaProduto == null)
            {
                return NotFound();
            }

            return View(vendaProduto);
        }

        // POST: VendaProdutos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vendaProduto = await _context.VendaProduto.FindAsync(id);
            if (vendaProduto != null)
            {
                _context.VendaProduto.Remove(vendaProduto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaProdutoExists(int id)
        {
            return _context.VendaProduto.Any(e => e.Quantidade == id);
        }
    }
}
