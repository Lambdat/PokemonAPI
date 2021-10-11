using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokemonAPI.Models;
using PokemonAPI.Services;
using Utility;

namespace PokemonAPI.Data
{
    public class DAOPokemon : IDAO<Pokemon>
    {

        private Database _db;

        public DAOPokemon()
        {
            _db = new Database("pokemon");
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
            List<Pokemon> ris = new List<Pokemon>();

            List<Dictionary<string, string>> righe = _db.Read(
                                                                 "select pokemon.id,pokemon.nome,pokemon.peso,pokemon.generazione,tipi.id as tipoId,tipi.nome as tipoPokemon,mosse.id as mossaid," +
                                                                 "mosse.nome as Mossa,mosse.tipo as tipoMossa,mosse.potenza,mosse.effettispeciali " +
                                                                 " from pokemon " +
                                                                 " inner join tipipokemon on pokemon.id = tipipokemon.pokemonid" +
                                                                 " inner join tipi on tipipokemon.tipoid = tipi.id " +
                                                                 " inner join mossepokemon on pokemon.id = mossepokemon.pokemonid " +
                                                                 " inner join mosse on mossepokemon.mossaid = mosse.id; "
                                                                 );

            foreach(var riga in righe)
            {
                Pokemon p = new Pokemon();
                p.FromDictionary(riga);    //Questo lo facciamo per i campi semplici

                //Per le liste di oggetti troviamo il valore della ["chiave"] e da li inizializziamo l'apposita lista
                //inizializziamo l'oggetto della lista corrispondente e valorizziamo le sue proprietà

                int tipoId = int.Parse(riga["tipoid"]);
                string tipoPokemon = riga["tipopokemon"]; 

                p.Tipi = new List<Tipo>()
                {
                    new Tipo()
                    {
                        Id=tipoId,
                        Nome=tipoPokemon
                    }
                };

                int mossaId = int.Parse(riga["mossaid"]);
                string nome = riga["mossa"]; 
                string tipo = riga["tipomossa"];
                int potenza =int.Parse(riga["potenza"]);
                string effettiSpeciali = riga["effettispeciali"];

                p.Mosse = new List<Mossa>()
                {
                    new Mossa()
                    {
                        Id=mossaId,
                        Nome=nome,
                        Tipo=tipo,
                        Potenza=potenza,
                        EffettiSpeciali=effettiSpeciali
                    }


                };


                ris.Add(p);
            }

            return ris;

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
