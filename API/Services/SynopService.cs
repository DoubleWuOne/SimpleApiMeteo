using API.Interfaces.Services;
using API.Responses;
using System.Net;
using System.Text.Json;

namespace API.Services
{
    public class SynopService : ISynopService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<SynopService> _logger;
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public SynopService(IHttpClientFactory httpClient, ILogger<SynopService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<SynopResponse?> GetSynopReportByIdAsync(int id)
        {
            var httpClient = _httpClient.CreateClient();
            var url = $"https://danepubliczne.imgw.pl/api/data/synop/id/{id}";
            using var response = await httpClient.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;
            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Błąd IMGW API: {response.StatusCode}");

            var content = await response.Content.ReadAsStringAsync(); //lub ReadFromJsonAsync 

            if (string.IsNullOrWhiteSpace(content))
                return null;

            var report = JsonSerializer.Deserialize<SynopResponse>(content, _jsonOptions);
            return report;
        }

        public async Task<List<SynopResponse>?> GetSynopReportFullAsync()
        {
            var httpClient = _httpClient.CreateClient();
            var url = "https://danepubliczne.imgw.pl/api/data/synop";
            using var response = await httpClient.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;
            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Błąd IMGW API: {response.StatusCode}");

            var content = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(content))
                return null;

            var report = JsonSerializer.Deserialize<List<SynopResponse>>(content, _jsonOptions);
            return report;
        }

        public async Task<SynopResponse?> GetSynopReportByNameAsync(string name) // istnieje juz api do tego, ale chciałem to samemu zrobic
        {
            var reports = await GetSynopReportFullAsync();
            return reports?.FirstOrDefault(x => string.Equals(x.Stacja, name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
