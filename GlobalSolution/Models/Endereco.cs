using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalSolution.Models
{
    public class Endereco
    {
        public long EnderecoId { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }

        public Cidade Cidade { get; set; }
    }
}
