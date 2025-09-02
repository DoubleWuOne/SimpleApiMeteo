using API.Exceptions;
using API.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class WeatherController : ControllerBase
    {
        private readonly ISynopService _synopService;

        public WeatherController(ISynopService synopService)
        {
            _synopService = synopService;
        }

        [HttpGet("synop")]
        public async Task<IActionResult> GetSynopData()
        {
            var report = await _synopService.GetSynopReportFullAsync();
            if (report == null || report.Count == 0)
                throw new NotFoundException($"No data found");
            return Ok(report);
        }

        [HttpGet("synop/{id}")]
        public async Task<IActionResult> GetSynopDataById(int id)
        {
            var report = await _synopService.GetSynopReportByIdAsync(id);
            if (report == null)
                throw new NotFoundException($"There is no station with this id: {id}");

            return Ok(report);
        }

        [HttpGet("synop/station/{name}")]
        public async Task<IActionResult> GetSynopDataByName(string name)
        {
            var report = await _synopService.GetSynopReportByNameAsync(name);
            if (report == null)
                throw new NotFoundException($"There is no station with this name:{name}");

            return Ok(report); //Controller not ControllerBase
        }
    }
}
