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

        public PokemonService(DAOPokemon _pokemon) //In StartUp.cs abbiamo bassato l'istanza singleton attraverso pattern Dependency Injection
        {
            this._pokemon = _pokemon;
        }



        public void Aggiungi(Pokemon t)
        {
            _pokemon.Aggiungi(t);
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
