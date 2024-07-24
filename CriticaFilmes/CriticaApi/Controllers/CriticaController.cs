using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CriticaApi.DAOs;
using CriticaApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CriticaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CriticaController : ControllerBase
    {
        public CriticaController()
        {
            dao = new CriticaDAO();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Critica>>> GetAsync()
        {
            var objetos = await dao.RetornarTodosAsync();

            if (objetos == null)
                return NotFound();

            return Ok(objetos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Critica>> GetId(string id)
        {
            var obj = await dao.RetornarPorIdAsync(id);

            if (obj == null)
                return NotFound();

            return obj;
        }

        [HttpPost]
        public async Task<ActionResult<Critica>> PostAsync(Critica obj)
        {
            await dao.InserirAsync(obj);

            return CreatedAtAction(
                nameof(GetId),
                new { id = obj.Id },
                obj
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(string id, Critica obj)
        {
            if (id != obj.Id)
                return BadRequest();

            var objOrig = await dao.RetornarPorIdAsync(id);

            if (objOrig == null)
                return NotFound();

            objOrig.NameFilme = obj.NameFilme;
            objOrig.Analise = obj.Analise;
            objOrig.Autor = obj.Autor;
            objOrig.Estrelas = obj.Estrelas;

            await dao.AlterarAsync(obj);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var obj = await dao.RetornarPorIdAsync(id);

            if (obj == null)
                return NotFound();

            await dao.ExcluirAsync(id);

            return NoContent();
        }

        private readonly CriticaDAO dao;
    }
}

