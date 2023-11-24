using GlobalSolution.Models;
using GlobalSolution.Service.dto;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GlobalSolution.Service
{
    public class MedicoService
    {
        private readonly RestClient _client;

        public MedicoService()
        {
            _client = new RestClient("https://saudepluss.azurewebsites.net/");
        }

        public async Task<IEnumerable<MedicoViewModel>> GetAllMedicosAsync()
        {
            var request = new RestRequest("medicos", Method.Get);
            var response = await _client.ExecuteAsync<IEnumerable<MedicoViewModel>>(request);
            if (!response.IsSuccessful)
                throw new HttpRequestException($"Erro na requisição: {response.StatusCode}");

            return response.Data;
        }

        public async Task<MedicoViewModel> GetMedicoByIdAsync(long id)
        {
            var request = new RestRequest($"medicos/{id}", Method.Get);
            var response = await _client.ExecuteAsync<MedicoViewModel>(request);
            if (!response.IsSuccessful)
                throw new HttpRequestException($"Erro na requisição: {response.StatusCode}");

            return response.Data;
        }

        public async Task<MedicoViewModel> CreateMedicoAsync(MedicoCadastroDTO medicoDTO)
        {
            var request = new RestRequest("medicos", Method.Post);
            request.AddJsonBody(medicoDTO);
            var response = await _client.ExecuteAsync<MedicoViewModel>(request);
            if (!response.IsSuccessful)
                throw new HttpRequestException($"Erro na requisição: {response.StatusCode}");

            return response.Data;
        }

        public async Task<MedicoViewModel> UpdateMedicoAsync(long id, MedicoCadastroDTO medicoDTO)
        {
            var request = new RestRequest($"medicos/{id}", Method.Put);
            request.AddJsonBody(medicoDTO);
            var response = await _client.ExecuteAsync<MedicoViewModel>(request);
            if (!response.IsSuccessful)
                throw new HttpRequestException($"Erro na requisição: {response.StatusCode}");

            return response.Data;
        }

        public async Task DeleteMedicoAsync(long id)
        {
            var request = new RestRequest($"medicos/{id}", Method.Delete);
            var response = await _client.ExecuteAsync(request);
            if (!response.IsSuccessful)
                throw new HttpRequestException($"Erro na requisição: {response.StatusCode}");
        }
    }
}
