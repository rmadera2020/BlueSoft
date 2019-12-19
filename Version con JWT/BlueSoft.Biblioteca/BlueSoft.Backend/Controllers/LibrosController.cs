namespace BlueSoft.Backend.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using BlueSoft.Backend.Data;
    using BlueSoft.Backend.Models;
    using Microsoft.AspNetCore.Authorization;

    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly BibliotecaDbContext _context;

        public LibrosController(BibliotecaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<List<Libro>> GetLibro()
        {
            var libros = (from l in _context.Libro
                          join a in _context.Autor
                          on l.IdAutor equals a.IdAutor
                          join c in _context.Categoria
                          on l.IdCategoria equals c.IdCategoria
                          select new Libro
                          {
                              IdLibro = l.IdLibro,
                              Nombre = l.Nombre,
                              IdAutor = l.IdAutor,
                              IdCategoria = l.IdCategoria,
                              Autor = new Autor() { IdAutor = l.IdAutor, Nombre = a.Nombre, Apellidos = a.Apellidos, FechaNac = a.FechaNac },
                              Categoria = new Categoria() { IdCategoria = l.IdCategoria, Nombre = c.Nombre, Descripcion = c.Descripcion },
                              ISBN = l.ISBN
                          }).ToList();

            return Ok(libros);
        }

        // GET: api/Libros/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Libro>> GetLibro(Guid id)
        {
            var libro = await _context.Libro.FindAsync(id);

            if (libro == null)
            {
                return NotFound();
            }

            return libro;
        }

        // PUT: api/Libros/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibro(Guid id, Libro libro)
        {
            if (id != libro.IdLibro)
            {
                return BadRequest();
            }

            _context.Entry(libro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibroExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Libros
        [HttpPost]
        public async Task<ActionResult<Libro>> PostLibro(Libro libro)
        {
            _context.Libro.Add(libro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLibro", new { id = libro.IdLibro }, libro);
        }

        // DELETE: api/Libros/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Libro>> DeleteLibro(Guid id)
        {
            var libro = await _context.Libro.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }

            _context.Libro.Remove(libro);
            await _context.SaveChangesAsync();

            return libro;
        }

        private bool LibroExists(Guid id)
        {
            return _context.Libro.Any(e => e.IdLibro == id);
        }
    }
}
