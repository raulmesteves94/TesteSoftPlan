using Microsoft.AspNetCore.Mvc;

namespace Api1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MainController : ControllerBase
    {
        private readonly ILogger<MainController> _logger;

        public MainController(ILogger<MainController> logger)
        {
            _logger = logger;
        }

        [HttpGet("taxaJuros")]
        public ActionResult<decimal> ObterTaxaJuros()
        {
            var taxaJuros = 0.01;

            return Ok(taxaJuros);
        }
    } 
}
