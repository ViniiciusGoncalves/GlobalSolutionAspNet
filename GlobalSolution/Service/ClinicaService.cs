using RestSharp;
using GlobalSolution.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlobalSolution.Service
{
    public class ClinicaService
    {
        private readonly RestClient _client;

        public ClinicaService()
        {
            _client = new RestClient("https://saudepluss.azurewebsites.net/");
        }

        public async Task<IEnumerable<ClinicaViewModel>> GetAllClinicasAsync()
        {
            var request = new RestRequest("hospitalclinicas/localizacao", Method.Get);
            var response = await _client.ExecuteAsync<List<ClinicaViewModel>>(request);
            if (response.IsSuccessful)
            {
                return response.Data;
            }
            return new List<ClinicaViewModel>();
        }
    }
}
