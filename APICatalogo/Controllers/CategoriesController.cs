using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriesController (AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("products")]
        public ActionResult<IEnumerable<Category>> GetCatagoriesProducts ()
        {
            return Ok(_context.Categories.Include(p => p.Products).ToList());
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get() {
            try
            {
                return _context.Categories.AsNoTracking().ToList();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter as categorias do banco de dados");
            }

        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public ActionResult<Category> Get(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            { 
                return NotFound("Categoria não encontrada");
            }
            return Ok(category);
        }

        [HttpPost]
        public ActionResult Post(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return new CreatedAtRouteResult("GetCategory", 
                new { id = category.CategoryId }, category);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest("Categoria não encontrada");
            }
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Category> Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound("Categoria não encontrada");
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return category;
        }
    }
}
