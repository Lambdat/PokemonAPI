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
            _db.Update("insert into tipi(nome) values " +
                $"('{t.Nome}')");


        }

        public Tipo Cerca(int id)
        {
            Tipo ris = new Tipo();
            
            Dictionary<string, string> riga = _db.ReadOne("select * from tipi where id=" + id);

            ris.FromDictionary(riga);

            return ris;
        }

        public List<Tipo> Elenco()
        {
            List<Tipo> ris = new List<Tipo>();

            List<Dictionary<string, string>> righe = _db.Read("select * from tipi");

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
