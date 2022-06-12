using System.Net.Http.Headers;

namespace Api2
{
    public class TaxaJurosHttpClient
    {
        private readonly HttpClient _httpClient;

        public TaxaJurosHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public decimal ObterTaxaJuros()
        {
            try
            {
                decimal taxaJuros = 0;

                HttpResponseMessage response = _httpClient.GetAsync("taxaJuros").Result;
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
