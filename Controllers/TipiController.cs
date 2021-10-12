﻿using Microsoft.AspNetCore.Http;
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
    public class TipiController : ControllerBase
    {

        private readonly IDAO<Tipo> _idao;

        public TipiController(IDAO<Tipo> _idao)
        {
            this._idao = _idao;
        }


        [HttpGet]
        public List<Tipo> Elenco()
        {
            return _idao.Elenco();
        }






    }
}