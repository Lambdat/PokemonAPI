using PokemonAPI.Data;
using PokemonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonAPI.Services
{
    public class TipiService : IDAO<Tipo>
    {
        private readonly DAOTipi _tipi;

        public TipiService(DAOTipi _tipi)
        {
            this._tipi = _tipi;
        }

        public void Aggiungi(Tipo t)
        {
            _tipi.Aggiungi(t);
        }

        public Tipo Cerca(int id)
        {
            return _tipi.Cerca(id);
        }

        public List<Tipo> Elenco()
        {
            return _tipi.Elenco();
        }

        public void Elimina(int id)
        {
            _tipi.Elimina(id);
        }

        public void Modifica(int id,Tipo p)
        {
            _tipi.Modifica(id,p);
        }
    }
}
