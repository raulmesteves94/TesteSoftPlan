using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Api2.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            var taxaJuros = ObterTaxaJuros();

            var valorJuros = valorInicial * Convert.ToDecimal(Math.Pow(1 + Convert.ToDouble(taxaJuros), tempo));

            return Ok(valorJuros.ToString("F2").Replace(",", "."));
        }

        [HttpGet("showmethecode")]
        public ActionResult<string> ShowMeTheCode()
        {
            return Ok("https://github.com/raulmesteves94/TesteSoftPlan.Api1");
        }

        private decimal ObterTaxaJuros()
        {
            decimal taxaJuros = 0;

            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                var client = new HttpClient(clientHandler);
                client.BaseAddress = new Uri(_configuration["Api1Url"]);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("Main/taxaJuros").Result;
                if (response.IsSuccessStatusCode)
                {
                    taxaJuros = response.Content.ReadFromJsonAsync<decimal>().Result;
                }

                return taxaJuros;
            }
            catch (Exception ex)
            {
                return taxaJuros;
            }
        }
    }
}