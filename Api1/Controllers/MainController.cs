using Microsoft.AspNetCore.Mvc;

namespace Api1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MainController : ControllerBase
    {
        public MainController()
        {

        }

        [HttpGet("taxaJuros")]
        public ActionResult<decimal> ObterTaxaJuros()
        {
            var taxaJuros = 0.01;

            return Ok(taxaJuros);
        }
    } 
}
