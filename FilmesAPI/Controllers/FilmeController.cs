using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOs;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("filme")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _conext;
        private IMapper _mapper;

        public FilmeController(FilmeContext context, IMapper mapper)
        {
            _conext = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto); 

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
            {
                ReadFilmeDto readFilmeDto = _mapper.Map<ReadFilmeDto>(filme);   
                return Ok(readFilmeDto);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilmesById(int Id, [FromBody] UpdateFilmeDto filmeDto)
        {
            var filme = _conext.Filmes.FirstOrDefault(f => f.Id == Id);
            if (filme == null)
            {
                return NotFound();
            }

            _mapper.Map(filmeDto, filme);

            _conext.Filmes.Update(filme);
            _conext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFilmesById(int id)
        {
            var filme = _conext.Filmes.FirstOrDefault(f => f.Id == id);
            if(filme == null)
            {
                return NotFound();
            }

            _conext.Filmes.Remove(filme);
            _conext.SaveChanges();
            return NoContent();
        }
    }
}
