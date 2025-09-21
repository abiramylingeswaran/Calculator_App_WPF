using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CalculatorApp.Commands;
using CalculatorApp.operation;

namespace CalculatorApp.ViewModel
{
    public class CalculatorCommandHandler : INotifyPropertyChanged
    {
        private string display = "0";
        private string historyText = "";        

        public event PropertyChangedEventHandler PropertyChanged;
        private readonly CalculatorViewModel viewModel;

        public string Display
        {
            get
            {
                return display;
            }
            set
            {
                display = value;
                OnPropertyChanged(nameof(Display));
            }
        }
        public string HistoryText
        {
            get 
            {
                return historyText;
            }
            set
            {
                historyText = value;
                OnPropertyChanged(nameof(HistoryText));
            }
        }
        public ICommand NumberCommand { get; }
        public ICommand OperatorCommand { get; }
        public ICommand EqualCommand { get; }
        public ICommand ClearCommand { get; }
        public ICommand BackspaceCommand { get; }
        public CalculatorCommandHandler()
        {
            viewModel = new CalculatorViewModel(this);

            NumberCommand = new RelayCommand(NumberCommandExecute);
            OperatorCommand = new RelayCommand(OperatorCommandExecute);
            EqualCommand = new RelayCommand(EqualCommandExecute);
            ClearCommand = new RelayCommand(ClearCommandExecute);
            BackspaceCommand = new RelayCommand(BackspaceCommandExecute);
        }
        private void NumberCommandExecute(object param)
        {
            if (param != null)
                viewModel.NumberClick(param.ToString());
        }
        private void OperatorCommandExecute(object param)
        {
            if (param != null)
                viewModel.OperatorClick(param.ToString());
        }
        private void EqualCommandExecute(object _)
        {
            viewModel.EqualButtonClick();
        }
        private void ClearCommandExecute(object _)
        {
            viewModel.ClearButtonClick();
        }
        private void BackspaceCommandExecute(object _)
        {
            viewModel.BackspaceClick();
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
