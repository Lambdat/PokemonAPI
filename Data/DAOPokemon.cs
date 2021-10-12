using Microsoft.Extensions.Configuration;
using PokemonAPI.Models;
using PokemonAPI.Services;
using System.Collections.Generic;
using Utility;

namespace PokemonAPI.Data
{
    public class DAOPokemon : IDAO<Pokemon>
    {

        private Database _db;

        public DAOPokemon(IConfiguration config)
        {
           string nomeDatabase = config.GetValue<string>(key: "NomeDatabase");

            _db = new Database(nomeDatabase);
        }



        public void Aggiungi(Pokemon t)
        {
            _db.Update("insert into pokemon(nome,peso,generazione) values " +
                $"('{t.Nome}',{t.Peso},{t.Generazione})");

        }

        public Pokemon Cerca(int id)
        {
            Pokemon ris = new Pokemon();

            Dictionary<string, string> riga = _db.ReadOne("select * from pokemon where id=" + id);


            //Nel caso non esistesse alcun Dictionary (o riga) riferito alla tabella
            if (riga is null)
            {
                return null;
            }

            ris.FromDictionary(riga);

            //Creaiamo e carichiamo la lista dei tipi del pokemon trovato

            ris.Tipi = new List<Tipo>();

            List<Dictionary<string, string>> righeTipi = _db.Read("select * " +
                                                                "from tipipokemon inner join tipi on tipipokemon.tipoid=tipi.id " +
                                                                $"where pokemonid={ris.Id}");

            foreach (var rigaTipo in righeTipi)
            {
                ris.Tipi.Add(new Tipo()
                {
                    Id = int.Parse(rigaTipo["id"]),
                    Nome = rigaTipo["nome"]
                });
            }


            //Creaiamo e carichiamo la lista dei pokemon del pokemon trovato

            ris.Mosse = new List<Mossa>();


            List<Dictionary<string, string>> righeMosse = _db.Read("select * " +
                "from mossepokemon inner join mosse on mossepokemon.mossaid=mosse.id " +
                $"where pokemonid={ris.Id}");

            foreach (var rigaMossa in righeMosse)
            {
                ris.Mosse.Add(new Mossa()
                {
                    Id = int.Parse(rigaMossa["id"]),
                    Nome = rigaMossa["nome"],
                    Tipo = rigaMossa["tipo"],
                    Potenza = int.Parse(rigaMossa["potenza"]),
                    EffettiSpeciali = rigaMossa["effettispeciali"]
                });
            }


            return ris;
        }

        public List<Pokemon> Elenco()
        {
            List<Pokemon> ris = new List<Pokemon>();

            List<Dictionary<string, string>> righe = _db.Read("select * from pokemon");

            foreach (var riga in righe)
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
                foreach (var rigaTipo in righeTipi)
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

                foreach (var rigaMossa in righeMosse)
                {
                    p.Mosse.Add(
                        new Mossa()
                        {
                            Id = int.Parse(rigaMossa["mossaid"]),
                            Nome = rigaMossa["nome"],
                            Tipo = rigaMossa["tipo"],
                            Potenza = int.Parse(rigaMossa["potenza"]),
                            EffettiSpeciali = rigaMossa["effettispeciali"]
                        });
                }




                ris.Add(p);
            }

            return ris;

        }

        public void Elimina(int id)
        {
            _db.Update("delete from pokemon where id=" + id);

        }


        //TODO : Finire la modifica per i pokemon
        public void Modifica(int id,Pokemon p)
        {
            _db.Update($"update pokemon set nome='{p.Nome}',peso={p.Peso},generazione={p.Generazione}" +
                $" where id={p.Id}");


        }


        public void Modifica(Pokemon p,List<Tipo> t)
        {
            foreach(Tipo tipo in t)
            {
            _db.Update($"update tipipokemon set tipoId={tipo.Id} " +
                $"where idpokemon={p.Id}");

            }
        }
    }
}
