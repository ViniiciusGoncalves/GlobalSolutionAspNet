using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalSolution.Models
{
    public class Paciente
    {
        public long PacienteId { get; set; }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Sexo { get; set; }
        public Endereco Endereco { get; set; }
    }
}
