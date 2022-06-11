using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Http.Headers;

namespace Api2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MainController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly ILogger<MainController> _logger;

        public MainController(ILogger<MainController> logger, IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = logger;

        }

        [HttpGet("calculajuros")]
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

                var taxaJuros = ObterTaxaJuros();

                var valorJuros = valorInicial * Convert.ToDecimal(Math.Pow(1 + Convert.ToDouble(taxaJuros), tempo));

                return Ok(valorJuros.ToString("F2").Replace(",", "."));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("showmethecode")]
        public ActionResult<string> ShowMeTheCode()
        {
            return Ok("https://github.com/raulmesteves94/TesteSoftPlan");
        }

        private decimal ObterTaxaJuros()
        {
            try
            {
                decimal taxaJuros = 0;
                HttpClient client = InicializarClient();

                HttpResponseMessage response = client.GetAsync("Main/taxaJuros").Result;
                if (response.IsSuccessStatusCode)
                {
                    taxaJuros = response.Content.ReadFromJsonAsync<decimal>().Result;
                }

                return taxaJuros;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private HttpClient InicializarClient()
        {
            HttpClientHandler clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            };

            var client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(_configuration["Api1Url"])
            };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}