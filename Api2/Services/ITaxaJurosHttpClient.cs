namespace Api2.Services;

public interface ITaxaJurosHttpClient
{
    Task<decimal?> ObterTaxaJuros();
}