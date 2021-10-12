using System;
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

            if (riga is null)
            {
                return null;
            }
            
            ris.FromDictionary(riga);

            return ris;
        }

        public List<Tipo> Elenco()
        {
            List<Tipo> ris = new List<Tipo>();

            List<Dictionary<string, string>> righe = _db.Read("select * from tipi");


            //Usiamo Linq sulle nostre liste di Dictionary<string,string>

            return righe.Select(riga =>
            {

                Tipo t = new Tipo();
                t.FromDictionary(riga);
                return t;

            }).ToList();
        
        }

        public void Elimina(int id)
        {
            _db.Update("delete from tipi where id=" + id);
        }

        public void Modifica(int id,Tipo t)
        {
            _db.Update($"update tipi set nome='{t.Nome}' where id={id}");
        }
    }
}
