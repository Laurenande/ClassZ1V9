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

namespace ClassN1V9
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

        Class1 obj;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                obj = new Class1(textbox1.Text, textbox2.Text, textbox3.Text, textbox4.Text);
                label1.Content = $"Длина = {obj.Dlina}";
                label2.Content = $"y = {obj.YravK}x + {obj.YravB}";
            }
            catch (Exception ex)
            {
                label1.Content = ex.Message;
            }

        }
    }
}
