using CalculatorApp.operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.ViewModel
{
    public class CalculatorViewModel
    {
        private readonly CalculatorCommandHandler commandHandler;

        private double firstNumber;
        private double secondNumber;
        private string operatorStr = "";
        private bool isNewEntry = true;
        private bool isEqualBtnClicked = false;
        private bool isOperatorClicked = false;

        public CalculatorViewModel(CalculatorCommandHandler commandHandler)
        {
            this.commandHandler = commandHandler;
        }

        public void NumberClick(string number)
        {
            if (isNewEntry)
            {
                commandHandler.Display = number;
                isNewEntry = false;
            }
            else
            {
                commandHandler.Display += number;
            }
            isEqualBtnClicked = false;
            isOperatorClicked = false;
        }       

        public void OperatorClick(string op)
        {
            bool isValidNumber = double.TryParse(commandHandler.Display, out double currentNumber);
            if (isValidNumber)
            {
                string result = commandHandler.Display;

                if (!string.IsNullOrEmpty(operatorStr) && !isOperatorClicked)
                {
                    var factory = new OperationFactory();
                    IOperation operation = factory.GetInstance(operatorStr);
                    if (operation != null)
                    {
                        secondNumber = currentNumber;
                        double[] numbers = new double[] { firstNumber, isEqualBtnClicked ? 0 : secondNumber };
                        result = operation.Execute(numbers);

                        if (double.TryParse(result, out double parsedResult))
                        {
                            firstNumber = parsedResult;                            
                        }
                        else
                        {
                            commandHandler.HistoryText = firstNumber.ToString() + " " + operatorStr;
                            commandHandler.Display = result;
                            RefreshAll();
                            return;
                        }
                    }
                }
                else
                {
                    firstNumber = currentNumber;                 
                }

                operatorStr = op;
                commandHandler.HistoryText = firstNumber.ToString() + " " + operatorStr;
                commandHandler.Display = result;
                isNewEntry = true;
                isOperatorClicked = true;
                isEqualBtnClicked = false;
            }
        }

        public void EqualButtonClick()
        {
            bool isValidNumber = double.TryParse(commandHandler.Display, out double currentNumber);
            if (isValidNumber)
            {
                var factory = new OperationFactory();
                IOperation operation = factory.GetInstance(operatorStr);
                string result;

                if (operation != null)
                {
                    if (isEqualBtnClicked)
                    {
                        firstNumber = double.TryParse(commandHandler.Display, out double lastResult) ? lastResult : firstNumber;
                    }
                    else
                    {
                        secondNumber = currentNumber;
                    }

                    double[] numbers = new double[] { firstNumber, secondNumber };
                    result = operation.Execute(numbers);
                    commandHandler.HistoryText = firstNumber.ToString() + " " + operatorStr + " " + secondNumber.ToString() + " =";

                    if (double.TryParse(result, out double parsedResult))
                    {
                        firstNumber = parsedResult;
                    }
                    else
                    {
                        commandHandler.HistoryText = firstNumber.ToString() + " " + operatorStr;
                        RefreshAll();
                    }
                }
                else
                {
                    result = commandHandler.Display;
                    commandHandler.HistoryText = currentNumber.ToString() + " =";
                }

                commandHandler.Display = result;
                isNewEntry = true;
                isEqualBtnClicked = true;
            }
        }

        public void ClearButtonClick()
        {
            commandHandler.Display = "0";
            commandHandler.HistoryText = "";
            RefreshAll();
        }

        public void BackspaceClick()
        {
            if (isEqualBtnClicked)
            {
                commandHandler.HistoryText = "";
                if (!double.TryParse(commandHandler.Display, out double displayResult))
                {
                    commandHandler.Display = "0";
                    isNewEntry = true;
                }
            }
            else if (!string.IsNullOrEmpty(commandHandler.Display) && commandHandler.Display != "0")
            {
                if (!isOperatorClicked)
                {
                    if (commandHandler.Display.Length > 1)
                    {
                        commandHandler.Display = commandHandler.Display.Substring(0, commandHandler.Display.Length - 1);
                    }
                    else
                    {
                        commandHandler.Display = "0";
                        isNewEntry = true;
                    }
                }                
            }
        }

        public void RefreshAll()
        {
            firstNumber = 0;
            secondNumber = 0;
            operatorStr = "";
            isNewEntry = true;
            isEqualBtnClicked = false;
            isOperatorClicked = false;
        }
    }
}
