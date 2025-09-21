using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculatorApp
{
    public partial class MainWindow : Window
    {
        private double firstNumber = 0;
        private double secondNumber;
        private string operatorStr = "";
        private bool isNewEntry = true;
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}