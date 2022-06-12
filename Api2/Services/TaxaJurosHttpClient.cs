namespace Api2.Services
{
    public class TaxaJurosHttpClient : ITaxaJurosHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<TaxaJurosHttpClient> _logger;

        public TaxaJurosHttpClient(HttpClient httpClient, ILogger<TaxaJurosHttpClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<decimal?> ObterTaxaJuros()
        {
            try
            {
                decimal taxaJuros = 0;

                HttpResponseMessage response = await _httpClient.GetAsync("TaxaJuros");
                if (response.IsSuccessStatusCode)
                {
                    taxaJuros = await response.Content.ReadFromJsonAsync<decimal>();
                }

                return taxaJuros;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter taxa de juros");
                return null;
            }
        }
    }
}
