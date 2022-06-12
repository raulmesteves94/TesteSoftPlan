namespace Api2.Services;

public interface ICalculaJurosService
{
    Task<decimal> Calcular(decimal valorInicial, int tempo);
}