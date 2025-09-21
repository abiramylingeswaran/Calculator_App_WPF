using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.operation
{
    public class OperationFactory
    {
        public IOperation GetInstance(string operationType)
        {
            IOperation operation = null;
            if (operationType == "+")
            {
                operation = new AddOperation();
            }
            else if (operationType == "-")
            {
                operation = new SubOperation();
            }
            else if (operationType == "*")
            {
                operation = new MulOperation();
            }
            else if (operationType == "/")
            {
                operation = new DivOperation();
            }
            return operation;
        }
    }
}
