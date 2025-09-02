using API.Responses;

namespace API.Interfaces.Services
{
    public interface ISynopService
    {
        public Task<SynopResponse?> GetSynopReportByIdAsync(int id);
        public Task<SynopResponse?> GetSynopReportByNameAsync(string name);
        public Task<List<SynopResponse>?> GetSynopReportFullAsync();
    }
}
