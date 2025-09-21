using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.operation
{
    public class DivOperation : IOperation
    {
        public string Execute(double[] numbers)
        {
            if (numbers == null || numbers.Length < 2)
                throw new ArgumentException("At least two numbers are required for division.");

            if (numbers[1] == 0)
                return "Cannot divide by zero";

            return (numbers[0] / numbers[1]).ToString();
        }    
    }
}
