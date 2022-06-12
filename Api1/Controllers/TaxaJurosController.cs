using Microsoft.AspNetCore.Mvc;

namespace Api1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaxaJurosController : ControllerBase
    {
        public TaxaJurosController()
        {

        }

        [HttpGet(Name = "taxaJuros")]
        public ActionResult<decimal> ObterTaxaJuros()
        {
            var taxaJuros = 0.01;

            return Ok(taxaJuros);
        }
    } 
}
