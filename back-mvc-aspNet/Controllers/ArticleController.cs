using back_mvc_aspNet.Context;
using back_mvc_aspNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_mvc_aspNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly PruebaMvcContext _context;

        public ArticleController(PruebaMvcContext context)
        {
            _context = context;
        }

        // GET: api/Article
        [HttpGet]
        public async Task<IActionResult> GetArticle()
        {
            try
            {
                var Article = await _context.Article.ToListAsync();
                return Ok(new { success = true, message = "Articulos obtenidos correctamente", data = Article });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "Error al listar los artículos", error = ex.Message });
            }
        }

        // GET: api/Article/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticle(int id)
        {
            var article = await _context.Article.FindAsync(id);
            if (article == null)
            {
                return NotFound(new { success = false, message = "Articulo no encontrado" });
            }
            return Ok(new { success = true, data = article });
        }

        // POST: api/Article
        [HttpPost]
        public async Task<IActionResult> CreateArticle(Article article)
        {
            if (ModelState.IsValid)
            {
                // Calculate the price automatically
                article.Price = article.Cost * 1.35m;

                // Set the added and modified date automatically
                article.AddedDate = DateTime.Now;
                article.ModifiedDate = DateTime.Now;

                _context.Article.Add(article);
                await _context.SaveChangesAsync();

                return Ok(new { success = true, message = "Artículo creado correctamente.", data = article });
            }

            return BadRequest(new { success = false, message = "Datos invalidos.", errors = ModelState.Values.SelectMany(v => v.Errors) });
        }

        // PUT: api/Article/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArticle(int id, Article article)
        {
            if (id != article.Id)
            {
                return BadRequest(new { success = false, message = "Datos invalidos." });
            }

            if (ModelState.IsValid)
            {
                var existingArticle = await _context.Article.FindAsync(id);
                if (existingArticle == null)
                {
                    return NotFound(new { success = false, message = "Articulo no encontrado." });
                }

                existingArticle.Code = article.Code;
                existingArticle.Name = article.Name;
                existingArticle.Description = article.Description;
                existingArticle.Cost = article.Cost;
                existingArticle.Price = article.Cost * 1.35m; // Update the price automatically
                existingArticle.IsActive = article.IsActive;
                existingArticle.ModifiedDate = DateTime.Now; // Update the modified date automatically

                await _context.SaveChangesAsync();

                return Ok(new { success = true, message = "Articulo actualizado correctamente", data = existingArticle });
            }

            return BadRequest(new { success = false, message = "Datos invalidos", errors = ModelState.Values.SelectMany(v => v.Errors) });
        }

        // DELETE: api/Article/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var article = await _context.Article.FindAsync(id);
            if (article == null)
            {
                return NotFound(new { success = false, message = "Articulo no encontrado." });
            }

            _context.Article.Remove(article);
            await _context.SaveChangesAsync();

            return Ok(new { success = true, message = "Articulo eliminado correctamente.", data = article });
        }
    }
}
