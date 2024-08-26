using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora.Models
{
    public class CalculadoraRequest
    {
        public double ValorInicial { get; set; }
        public int Meses { get; set; }
    }
   
        public class CalculadoraResult
        {
            public decimal FinalBruto { get; set; }
            public decimal FinalLiquido { get; set; }
        }
    

}
