using PatientTracker.Models;
using System.Net.Http.Json;

namespace PatientTracker.Services
{

public class PatientAPIService
    {
        private readonly HttpClient _client;

        public PatientAPIService(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("PatientAPI");
        }

        public async Task<List<Patient>> GetPatientsAsync()
        {
            return await _client.GetFromJsonAsync<List<Patient>>("api/Patients");
        }

        public async Task<Patient> GetPatientAsync(int id)
        {
            return await _client.GetFromJsonAsync<Patient>($"api/Patients/{id}");
        }

        public async Task CreatePatientAsync(Patient patient)
        {
            await _client.PostAsJsonAsync("api/Patients", patient);
        }

        public async Task UpdatePatientAsync(int id, Patient patient)
        {
            await _client.PutAsJsonAsync($"api/Patients/{id}", patient);
        }

        public async Task DeletePatientAsync(int id)
        {
            await _client.DeleteAsync($"api/Patients/{id}");
        }
    }

}
