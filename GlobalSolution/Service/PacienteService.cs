using GlobalSolution.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GlobalSolution.Service
{
    public class PacienteService
    {
        private readonly RestClient _client;

        public PacienteService()
        {
            _client = new RestClient("https://saudepluss.azurewebsites.net/");
        }

        public async Task<IEnumerable<Paciente>> GetAllPacientesAsync()
        {
            var request = new RestRequest("pacientes", Method.Get);
            var response = await _client.ExecuteAsync<IEnumerable<Paciente>>(request);
            if (!response.IsSuccessful)
                throw new HttpRequestException($"Erro na requisição: {response.StatusCode}");

            return response.Data;
        }

        public async Task<Paciente> GetPacienteByIdAsync(long id)
        {
            var request = new RestRequest($"pacientes/{id}", Method.Get);
            var response = await _client.ExecuteAsync<Paciente>(request);
            if (!response.IsSuccessful)
                throw new HttpRequestException($"Erro na requisição: {response.StatusCode}");

            return response.Data;
        }

        public async Task<IEnumerable<Estado>> GetEstadosAsync()
        {
            var request = new RestRequest("estados", Method.Get);
            var response = await _client.ExecuteAsync<IEnumerable<Estado>>(request);
            if (!response.IsSuccessful)
                throw new HttpRequestException($"Erro na requisição: {response.StatusCode}");

            return response.Data;
        }

        public async Task<IEnumerable<Cidade>> GetCidadesAsync()
        {
            var request = new RestRequest("cidades", Method.Get);
            var response = await _client.ExecuteAsync<IEnumerable<Cidade>>(request);
            if (!response.IsSuccessful)
                throw new HttpRequestException($"Erro na requisição: {response.StatusCode}");

            return response.Data;
        }

        public async Task<Paciente> CreatePacienteAsync(PacienteCadastroDTO pacienteDTO)
        {
            var request = new RestRequest("pacientes", Method.Post);
            request.AddJsonBody(pacienteDTO);
            var response = await _client.ExecuteAsync<Paciente>(request);
            if (!response.IsSuccessful)
                throw new HttpRequestException($"Erro na requisição: {response.StatusCode}");

            return response.Data;
        }

        public async Task<Paciente> UpdatePacienteAsync(long id, PacienteCadastroDTO pacienteDTO)
        {
            var request = new RestRequest($"pacientes/{id}", Method.Put);
            request.AddJsonBody(pacienteDTO);
            var response = await _client.ExecuteAsync<Paciente>(request);
            if (!response.IsSuccessful)
                throw new HttpRequestException($"Erro na requisição: {response.StatusCode}");

            return response.Data;
        }

        public async Task DeletePacienteAsync(long id)
        {
            var request = new RestRequest($"pacientes/{id}", Method.Delete);
            var response = await _client.ExecuteAsync(request);
            if (!response.IsSuccessful)
                throw new HttpRequestException($"Erro na requisição: {response.StatusCode}");
        }
    }
}
