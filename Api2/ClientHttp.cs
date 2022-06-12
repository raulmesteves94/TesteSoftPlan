using System.Net.Http.Headers;

namespace Api2
{
    public class ClientHttp
    {
        private IConfiguration _configuration;

        public ClientHttp(IConfiguration configuration)
        {
            _configuration = configuration;

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

        public decimal ObterTaxaJuros()
        {
            try
            {
                decimal taxaJuros = 0;
                HttpClient client = InicializarClient();

                HttpResponseMessage response = client.GetAsync("taxaJuros").Result;
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
    }
}
