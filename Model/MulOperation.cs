using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.operation
{
    public class MulOperation:IOperation
    {
        public string Execute(double[] numbers)
        {
            if (numbers == null || numbers.Length < 2)
                throw new ArgumentException("At least two numbers are required for multiplication.");

            return (numbers[0] * numbers[1]).ToString();
        }
    }
}
