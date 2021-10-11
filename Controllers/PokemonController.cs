using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models;
using PokemonAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {

        private readonly IDAO<Pokemon> _idao;

        public PokemonController(IDAO<Pokemon> _idao)
        {
            this._idao = _idao;
        }

        [HttpGet]
        public List<Pokemon> Elenco()
        {
            return _idao.Elenco();
        }

        [HttpGet("{id}")]
        public Pokemon Cerca([FromRoute]int id)
        {
            return _idao.Cerca(id);
        }

        [HttpPost]
        public IActionResult Aggiungi([FromBody]Pokemon p)
        {
            _idao.Aggiungi(p);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Elimina([FromRoute]int id)
        {
            _idao.Elimina(id);

            return Ok();
        }

    }
}
