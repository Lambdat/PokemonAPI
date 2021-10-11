using PokemonAPI.Data;
using PokemonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonAPI.Services
{
    public class PokemonService : IDAO<Pokemon>
    {
        private readonly DAOPokemon _pokemon;

        public PokemonService(DAOPokemon _pokemon)
        {
            this._pokemon = _pokemon;
        }



        public void Aggiungi(Pokemon t)
        {
            throw new NotImplementedException();
        }

        public Pokemon Cerca(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pokemon> Elenco()
        {
            return _pokemon.Elenco();
        }

        public void Elimina(int id)
        {
            throw new NotImplementedException();
        }

        public void Modifica(Pokemon t)
        {
            throw new NotImplementedException();
        }
    }
}
