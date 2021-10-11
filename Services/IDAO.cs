using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonAPI.Services
{
    public interface IDAO<T>
    {
        public List<T> Elenco();

        public T Cerca(int id);

        public void Aggiungi(T t);

        public void Modifica(T t);

        public void Elimina(int id);

    }
}
