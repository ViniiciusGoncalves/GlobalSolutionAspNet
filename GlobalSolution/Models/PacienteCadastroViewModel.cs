using GlobalSolution.Service;
using System;
using System.Collections.Generic;

namespace GlobalSolution.Models
{
    public class PacienteCadastroViewModel
    {
        public Paciente Paciente { get; set; }
        public Endereco Endereco { get; set; }
        public IEnumerable<Estado> Estados { get; set; }
        public IEnumerable<Cidade> Cidades { get; set; }
        public string NomeEstado { get; set; }
        public string NomeCidade { get; set; }

        public PacienteCadastroDTO ToPacienteCadastroDTO()
        {
            return new PacienteCadastroDTO
            {
                Nome = this.Paciente.Nome,
                DataNascimento = this.Paciente.DataNascimento,
                Sexo = this.Paciente.Sexo,
                Rua = this.Endereco.Rua,
                Numero = this.Endereco.Numero,
                Cep = this.Endereco.Cep,
                NomeCidade = this.NomeCidade,
                NomeEstado = this.NomeEstado
            };
        }
    }


}
