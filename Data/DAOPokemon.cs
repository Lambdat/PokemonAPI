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

            List<Dictionary<string, string>> righe = _db.Read("select * from pokemon");

            foreach(var riga in righe)
            {
                Pokemon p = new Pokemon();
                p.FromDictionary(riga);    //Questo lo facciamo per i campi semplici

                //Per le liste di oggetti troviamo il valore della ["chiave"] e da li inizializziamo l'apposita lista
                //inizializziamo l'oggetto della lista corrispondente e valorizziamo le sue proprietà

                //Carichiamo la lista di Tipi dell'oggetto
                p.Tipi = new List<Tipo>();

      

                List<Dictionary<string, string>> righeTipi = _db.Read("select tipi.id as tipoid,tipi.nome as tiponome " +
                                                     " from tipipokemon inner join tipi on tipipokemon.tipoid = tipi.id " +
                                                     $" where pokemonid={riga["id"]} "
                                                                    );
                foreach(var rigaTipo in righeTipi)
                {
                    p.Tipi.Add(
                            new Tipo()
                            {
                                Id = int.Parse(rigaTipo["tipoid"]),
                                Nome = rigaTipo["tiponome"]

                            });
                }


                //Carichiamo la lista di Mosse dell'oggetto
                p.Mosse = new List<Mossa>();

                List<Dictionary<string, string>> righeMosse = _db.Read("select * " +
                                                                    "from mossepokemon inner join mosse on mossepokemon.mossaid = mosse.id " +
                                                                    $"where pokemonid={riga["id"]} "
                                                                    );

                foreach(var rigaMossa in righeMosse)
                {
                    p.Mosse.Add(
                        new Mossa()
                        {
                            Id=int.Parse(rigaMossa["mossaid"]),
                            Nome=rigaMossa["nome"],
                            Tipo=rigaMossa["tipo"],
                            Potenza=int.Parse(rigaMossa["potenza"]),
                            EffettiSpeciali=rigaMossa["effettispeciali"]
                        });
                }

               


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
