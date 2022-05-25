using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("filme")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _conext;

        public FilmeController(FilmeContext context)
        {
            _conext = context;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            _conext.Filmes.Add(filme);
            _conext.SaveChanges();
            return CreatedAtAction(nameof(RecuperarFilmesById), new { Id = filme.Id}, filme);
        }

        [HttpGet]
        public IActionResult RecuperarFilmes()
        {
            return Ok(_conext.Filmes);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarFilmesById(int id)
        {
            var filme = _conext.Filmes.FirstOrDefault(f => f.Id == id);
            if(filme != null)
                return Ok(filme);

            return NotFound();
        }
    }
}
