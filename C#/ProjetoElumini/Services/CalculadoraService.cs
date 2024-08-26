using System.Threading.Tasks;
using Calculadora.Models; // Ajuste o namespace conforme necessário

namespace Calculadora.Services
{
    public class CdbCalculatorService : ICalculadoraService
    {
        public Task<CalculadoraResult> CalcularAsync(CalculadoraRequest request)
        {
            const decimal CDI = 0.009m; // CDI de 0,9%
            const decimal TB = 1.08m; // 108%
            decimal CDITB = CDI * TB;

            decimal VFBRUTO = (decimal)request.ValorInicial * (decimal)Math.Pow((double)(1 + CDITB), request.Meses);
            decimal LUCRO = VFBRUTO - (decimal)request.ValorInicial;

            decimal Imposto;
            if (request.Meses <= 6)
            {
                Imposto = 0.225m;
            }
            else if (request.Meses <= 12)
            {
                Imposto = 0.20m;
            }
            else if (request.Meses <= 24)
            {
                Imposto = 0.175m;
            }
            else
            {
                Imposto = 0.15m;
            }

            decimal VFBRUTOLIQUIDO = (decimal)request.ValorInicial + (LUCRO * (1 - Imposto));

            var result = new CalculadoraResult
            {
                FinalBruto = VFBRUTO,
                FinalLiquido = VFBRUTOLIQUIDO
            };

            return Task.FromResult(result);
        }
    }
}
