﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlueSoft.Backend.Data;
using BlueSoft.Backend.Models;
using Microsoft.AspNetCore.Authorization;

namespace BlueSoft.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class AutoresController : ControllerBase
    {
        private readonly BibliotecaDbContext _context;

        public AutoresController(BibliotecaDbContext context)
        {
            _context = context;
        }

        // GET: api/Autores
        [HttpGet]
        [Authorize] //------->> OJO
        public async Task<ActionResult<IEnumerable<Autor>>> GetAutor()
        {
            return await _context.Autor.ToListAsync();
        }

        // GET: api/Autores/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Autor>> GetAutor(Guid id)
        {
            var autor = await _context.Autor.FindAsync(id);

            if (autor == null)
            {
                return NotFound();
            }

            return autor;
        }

        // PUT: api/Autores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutor(Guid id, Autor autor)
        {
            if (id != autor.IdAutor)
            {
                return BadRequest();
            }

            _context.Entry(autor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutorExists(id))
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

        // POST: api/Autores
        [HttpPost]
        public async Task<ActionResult<Autor>> PostAutor(Autor autor)
        {
            _context.Autor.Add(autor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutor", new { id = autor.IdAutor }, autor);
        }

        // DELETE: api/Autores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Autor>> DeleteAutor(Guid id)
        {
            var autor = await _context.Autor.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }

            _context.Autor.Remove(autor);
            await _context.SaveChangesAsync();

            return autor;
        }

        private bool AutorExists(Guid id)
        {
            return _context.Autor.Any(e => e.IdAutor == id);
        }
    }
}
