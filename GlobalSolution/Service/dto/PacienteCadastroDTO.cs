using System;

namespace GlobalSolution.Service
{
    public class PacienteCadastroDTO
    {
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public string NomeCidade { get; set; }
        public string NomeEstado { get; set; }
    }
}