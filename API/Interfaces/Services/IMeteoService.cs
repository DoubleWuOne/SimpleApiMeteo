using Microsoft.AspNetCore.Mvc;

namespace API.Interfaces.Services
{
    public interface IMeteoService
    {
        public Task<JsonResult> GetMeteoReportAsync();
    }
}
