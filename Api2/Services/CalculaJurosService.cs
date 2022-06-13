namespace Api2.Services;
public class CalculaJurosService : ICalculaJurosService
{
    private readonly ITaxaJurosHttpClient _client;

    public CalculaJurosService(ITaxaJurosHttpClient client)
    {
        _client = client;
    }

    public async Task<decimal> Calcular(decimal valorInicial, int tempo)
    {
        var taxaJuros = await _client.ObterTaxaJuros();

        var valorFinal = Math.Truncate(valorInicial * Convert.ToDecimal(Math.Pow(1 + Convert.ToDouble(taxaJuros), tempo)) * 100) / 100;

        return Convert.ToDecimal(valorFinal);
    }
}
