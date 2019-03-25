using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3i3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var consub = new ConcreteSubject();
            var dec = new Decimal();
            var bin = new Binary();
            var oct = new Octal();
            var hex = new Hex();

            consub.AddObserver(dec);
            consub.AddObserver(bin);
            consub.AddObserver(oct);
            consub.AddObserver(hex);
            consub.NextNumber();
        }
    }
}
