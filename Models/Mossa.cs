using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;

namespace PokemonAPI.Models
{
    public class Mossa : Entity
    {
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public int Potenza { get; set; }
        public string EffettiSpeciali{ get; set; }
        
    }
}
