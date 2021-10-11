using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;

namespace PokemonAPI.Models
{
    public class Pokemon : Entity
    {
        public string Nome { get; set; }
        public double Peso { get; set; }
        public int Generazione { get; set; }
        public List<Tipo> Tipi {get; set;}
        public List<Mossa> Mosse {get; set;}
    }
}
