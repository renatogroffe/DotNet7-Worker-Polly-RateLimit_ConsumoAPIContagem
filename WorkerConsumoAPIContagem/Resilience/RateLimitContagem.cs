using Polly;
using Polly.RateLimit;
using WorkerConsumoAPIContagem.Models;

namespace WorkerConsumoAPIContagem.Resilience;

public class RateLimitContagem
{
    public static AsyncRateLimitPolicy<ResultadoContador> CreateRateLimitPolicy()
    {
        return Policy.RateLimitAsync<ResultadoContador>(
            numberOfExecutions: 1, perTimeSpan: TimeSpan.FromSeconds(1),
            (_, _) =>
            {
                Console.Out.WriteLineAsync();
                var previousForegroundColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Out.WriteLineAsync($" ***** Gerando valor alternativo via Policy de RateLimit... ***** ");
                Console.ForegroundColor = previousForegroundColor;
                Console.Out.WriteLineAsync();

                return new ResultadoContador()
                {
                    ValorAtual = -1,
                    Mensagem = "Valor gerado na Policy de Rate Limit"
                };
            });
    }
}