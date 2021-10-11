using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokemonAPI.Models;
using PokemonAPI.Services;
using Utility;

namespace PokemonAPI.Data
{
    public class DAOMosse : IDAO<Mossa>
    {

        private Database _db;

        public DAOMosse()
        {
            _db = new Database("pokemon");
        }

        public void Aggiungi(Mossa t)
        {
            throw new NotImplementedException();
        }

        public Mossa Cerca(int id)
        {
            throw new NotImplementedException();
        }

        public List<Mossa> Elenco()
        {
            List<Mossa> ris = new List<Mossa>();

            List<Dictionary<string, string>> righe = _db.Read("select * from mosse");

            foreach(var riga in righe)
            {
                Mossa m = new Mossa();
                m.FromDictionary(riga);
                ris.Add(m);
            }
        
            return ris;
        }

        public void Elimina(int id)
        {
            throw new NotImplementedException();
        }

        public void Modifica(Mossa t)
        {
            throw new NotImplementedException();
        }
    }
}
