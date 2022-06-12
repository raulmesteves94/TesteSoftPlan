using Api2.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Http.Headers;

namespace Api2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculaJurosController : ControllerBase
    {

        public CalculaJurosController()
        {
        }

        [HttpGet(Name = "calculajuros")]
        public async Task<ActionResult<decimal>> CalcularJuros(
            [FromServices] ICalculaJurosService service, 
            decimal valorInicial, 
            int tempo)
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

                var valorFinal = await service.Calcular(valorInicial, tempo);

                return Ok(valorFinal.ToString("F2").Replace(",", "."));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}