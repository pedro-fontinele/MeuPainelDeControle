using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeuPainelDeControle.Data;
using MeuPainelDeControle.Models;

namespace MeuPainelDeControle.Controllers
{
    public class EstoqueController : Controller
    {
        private readonly SistemaContext _context;

        public EstoqueController(SistemaContext context)
        {
            _context = context;
        }

        // Busca estoque em formato de lista
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estoques.ToListAsync());
        }

        // Carrega pagina de estoque vazia para ação de cadastro
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Insere no banco o cadastro de um novo estoque 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProduto,EstoqueProduto,TipoEmbalagem")] Estoque estoque)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estoque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estoque);
        }

        // Carrega pagina de edição do estoque já cadastrado
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else if (id != null)
            {
                var estoque = await _context.Estoques.FindAsync(id);
                return View(estoque);
            }
            return NotFound();
        }

        // Envia a alteracao do cadastro de estoque carregado no metodo anterior
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProduto, EstoqueProduto, TipoEmbalagem")] Estoque estoque)
        {
            if (id != estoque.Id || id == 0)
            {
                return NotFound();
            }
            else if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estoque);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch(DbUpdateConcurrencyException a)
                {
                    return View(a.Message);
                }
            }
            return View(estoque);
        }

        // Carrega a pagina de delete do item
        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete (int? id)
        {
            if  (id == null)
            {
                return NotFound();
            }
            else if (id != null)
            {
                var estoque = await _context.Estoques.FindAsync(id);
                return View(estoque);
            }
            return NotFound();
        }

        // Realiza o detele do dados buscado no metodo anterior
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (int? id)
        {
            var estoque = await _context.Estoques.FindAsync(id);
            _context.Estoques.Remove(estoque);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
