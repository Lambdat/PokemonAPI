﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokemonAPI.Models;
using PokemonAPI.Services;
using Utility;

namespace PokemonAPI.Data
{
    public class DAOTipi : IDAO<Tipo>
    {
        private Database _db;

        public DAOTipi()
        {
            _db = new Database("pokemon");
        }



        public void Aggiungi(Tipo t)
        {
            throw new NotImplementedException();
        }

        public Tipo Cerca(int id)
        {
            throw new NotImplementedException();
        }

        public List<Tipo> Elenco()
        {
            List<Tipo> ris = new List<Tipo>();

            List<Dictionary<string, string>> righe = _db.Read("select * from elenco");

            foreach(var riga in righe)
            {
                Tipo t = new Tipo();
                t.FromDictionary(riga);
                ris.Add(t);
            }

            return ris;
        }

        public void Elimina(int id)
        {
            throw new NotImplementedException();
        }

        public void Modifica(Tipo t)
        {
            throw new NotImplementedException();
        }
    }
}