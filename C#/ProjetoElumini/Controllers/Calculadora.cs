using Microsoft.AspNetCore.Mvc;
using Calculadora.Models;
using Calculadora.Services;
using System.Threading.Tasks;

namespace Calculadora.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CdbCalculatorController : ControllerBase
    {
        private readonly ICalculadoraService _cdbCalculatorService;

        public CdbCalculatorController(ICalculadoraService cdbCalculatorService)
        {
            _cdbCalculatorService = cdbCalculatorService;
        }

        [HttpPost]

        public async Task<IActionResult> Calcular([FromBody] CalculadoraRequest request)
        {
            if (request == null)
            {
                return BadRequest("Requisição inválida.");
            }

            try
            {
                var resultado = await _cdbCalculatorService.CalcularAsync(request);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                // Log a exceção se necessário
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
        
    }

}
