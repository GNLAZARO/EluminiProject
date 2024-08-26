using System.Threading.Tasks;
using Calculadora.Models; 

namespace Calculadora.Services
{
    public interface ICalculadoraService
    {
        Task<CalculadoraResult> CalcularAsync(CalculadoraRequest request);
    }
}
