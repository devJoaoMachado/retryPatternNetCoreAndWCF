using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PollyNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DateTimeController : ControllerBase
    {
        private GetDateTimeService _getDateTimeService = 
            new GetDateTimeService("http://localhost/WCFPolly/GetDateTimeService.svc");

        [HttpGet]
        [Route("get-time-central-us")]
        public async Task<string> GetDateTimeCentralUSAsync()
        {
            return await _getDateTimeService.GetDateTimeCentralUSAsync();
        }
    }
}
