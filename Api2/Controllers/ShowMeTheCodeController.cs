using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Http.Headers;

namespace Api2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShowMeTheCodeController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly ILogger<ShowMeTheCodeController> _logger;

        public ShowMeTheCodeController(ILogger<ShowMeTheCodeController> logger, IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = logger;

        }

        [HttpGet(Name = "showmethecode")]
        public ActionResult<string> ShowMeTheCode()
        {
            return Ok("https://github.com/raulmesteves94/TesteSoftPlan");
        }
    }
}