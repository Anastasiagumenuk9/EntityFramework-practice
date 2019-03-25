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

namespace WpfApp2.і2
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

        int n = 0;

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
      {
           
            TB1.Text = "Intel";

        }

        private void RadioButton2_Checked(object sender, RoutedEventArgs e)
        {
           
            TB1.Text = "AMD";

        }

        private void RadioButton3_Checked(object sender, RoutedEventArgs e)
        {

            TB2.Text = " Samsung";

        }
        private void RadioButton4_Checked(object sender, RoutedEventArgs e)
        {

            TB2.Text = "LG";

        }

        private void RadioButton5_Checked(object sender, RoutedEventArgs e)
        {

            TB3.Text = "None";

        }

        private void RadioButton6_Checked(object sender, RoutedEventArgs e)
        {

            TB3.Text = " Stereo";

        }
        private void RadioButton7_Checked(object sender, RoutedEventArgs e)
        {

            TB3.Text = " Surround";

        }

        private void TB1_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            n++;
            string monitor;
            string speakers;
            string cpu;
            cpu = TB1.Text;
            monitor = TB2.Text;
            speakers = TB3.Text;

            RobotBuilder Robotbuilder = new ConcreteRobotBuilder(); //Конкретний будівельник
            RobotDirector director = new RobotDirector(Robotbuilder, cpu, monitor, speakers); //Вказівка будівельнику
            director.Construct(); //будувати
            Robot product = Robotbuilder.GetResult();//Створення робота

            


            switch(n)  {

                case 1 :
                    MessageBoxResult result = MessageBox.Show("Робот з процесором " + TB1.Text + "  монітором " + TB2.Text + "  та динаміками " + TB3.Text + " створений!");
                    LB1.ItemsSource = product.parts;
                    I1.Source = BitmapFrame.Create(new Uri(@"F:\2 курс\2 семестр\ООП\Практична2\WpfApp2.і2\WpfApp2.і2\Фото\1.jpg"));
                    break;
                case 2 :
                    MessageBoxResult result1 = MessageBox.Show("Робот з процесором " + TB1.Text + "  монітором " + TB2.Text + "  та динаміками " + TB3.Text + " створений!");
                    LB2.ItemsSource = product.parts;
                    I2.Source = BitmapFrame.Create(new Uri(@"F:\2 курс\2 семестр\ООП\Практична2\WpfApp2.і2\WpfApp2.і2\Фото\2.jpg"));
                    break;
                case 3:
                    MessageBoxResult result2 = MessageBox.Show("Робот з процесором " + TB1.Text + "  монітором " + TB2.Text + "  та динаміками " + TB3.Text + " створений!");
                    LB3.ItemsSource = product.parts;
                    I3.Source = BitmapFrame.Create(new Uri(@"F:\2 курс\2 семестр\ООП\Практична2\WpfApp2.і2\WpfApp2.і2\Фото\3.png"));
                    break;
                default:
                    MessageBoxResult resultt = MessageBox.Show("Три роботи вже створенi");
                    break;
            }
        }

        private void TB1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

    
}
