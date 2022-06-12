using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Http.Headers;

namespace Api2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculaJurosController : ControllerBase
    {
        private readonly TaxaJurosHttpClient _client;

        public CalculaJurosController(TaxaJurosHttpClient client)
        {
            _client = client;
        }

        [HttpGet(Name = "calculajuros")]
        public ActionResult<decimal> CalcularJuros(decimal valorInicial, int tempo)
        {
            try
            {
                if(tempo <= 0)
                {
                    return BadRequest("Deve ser informada uma quantidade de meses maior que zero!");
                }

                if (valorInicial <= 0)
                {
                    return BadRequest("Deve ser informado um valor inicial maior que zero!");
                }

                var taxaJuros = _client.ObterTaxaJuros();

                var valorJuros = valorInicial * Convert.ToDecimal(Math.Pow(1 + Convert.ToDouble(taxaJuros), tempo));

                return Ok(valorJuros.ToString("F2").Replace(",", "."));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}