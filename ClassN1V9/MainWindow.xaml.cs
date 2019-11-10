using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
        Class2 obj1;

        List<Class2> Class2;
        List<Class1> Class1;

         List<string> ColorArr = new List<string>() { "Orange", "Black", "White", "Yellow" };
        public string er;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckColorBox.IsChecked == true)
                {
                    obj = new Class2(textbox1.Text, textbox2.Text, textbox3.Text, textbox4.Text, ColorBox.SelectedValue.ToString());
                    
                    label1.Content = $"Длина = {obj.Dlina}";
                    label2.Content = $"y = {obj.YravK}x + {obj.YravB}";
                    label3.Content = $"Цвет = {obj1.Color}";
                }
                else
                {
                    obj = new Class1(textbox1.Text, textbox2.Text, textbox3.Text, textbox4.Text);
                    label1.Content = $"Длина = {obj.Dlina}";
                    label2.Content = $"y = {obj.YravK}x + {obj.YravB}";
                }
                    
            }
            catch (Exception ex)
            {
                label1.Content = ex.Message;
            }

        }
        //Создание
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (obj1 == null)
                    Class1 = new List<Class1>(Convert.ToInt32(ArraySizeBox.Text));
                else Class2 = new List<Class2>(Convert.ToInt32(ArraySizeBox.Text));
                DataGrid1.ItemsSource = null;
            }
            catch (Exception)
            {
                MessageBox.Show("Размерность массива не задана");
            }
        }
        //Добавление
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (obj1 != null)
            {
                if (Class2 != null)
                {
                    if (!Class2.Contains(obj1))
                    {

                        if (Class2.Count < Class2.Capacity)
                        {
                            Class2.Add(obj1);
                            DataGrid1.ItemsSource = null;
                            DataGrid1.ItemsSource = Class2;
                        }
                        else { MessageBox.Show("Массив заполнен"); }
                    }
                    else
                    { MessageBox.Show("Элемент уже существует"); }
                }
                else { MessageBox.Show("Массив не создан"); }
            }

            if (obj != null && Class1 != null)
            {
                if (!Class1.Contains(obj))
                {

                    if (Class1.Count < Class1.Capacity)
                    {
                        Class1.Add(obj);
                        DataGrid1.ItemsSource = null;
                        DataGrid1.ItemsSource = Class1;
                    }
                    else { MessageBox.Show("Массив заполнен"); }
                }
                else
                { MessageBox.Show("Элемент уже существует"); }
            }
            else { MessageBox.Show("Массив не создан"); }


        }

        //Очистить
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Class2 = null;
            Class1 = null;
            DataGrid1.ItemsSource = Class1;

        }
        private void CheckColorBox_Checked(object sender, RoutedEventArgs e)
        {
            ColorBox.IsEnabled = true;
            ColorBox.ItemsSource = ColorArr;
            obj = null;
            obj1 = null;
            Class2 = null;
            Class1 = null;
            DataGrid1.ItemsSource = null;
        }

        private void CheckColorBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ColorBox.IsEnabled = false;
            label1.Content = ":";
            obj = null;
            obj1 = null;
            Class2 = null;
            Class1 = null;
            DataGrid1.ItemsSource = null;
        }

        private void CheckColorBox_Checked1(object sender, RoutedEventArgs e)
        {
            FilterColorBox.IsEnabled = true;
            FilterColorBox.ItemsSource = ColorArr;
        }

        private void CheckColorBox_Unchecked1(object sender, RoutedEventArgs e)
        {
            FilterColorBox.IsEnabled = false;
            if (obj1 != null)
            {
                DataGrid1.ItemsSource = Class2;
            }
            else
            {
                DataGrid1.ItemsSource = Class1;
            }
        }

        private void FilterColorBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Class2> FiltredPentagons = new List<Class2>();
            if (Class2 != null)
            {
                for (int i = 0; i < Class2.Count; i++)
                {
                    if (Class2[i].Color == FilterColorBox.SelectedItem.ToString())
                    {
                        FiltredPentagons.Add(Class2[i]);
                    }
                }
                DataGrid1.ItemsSource = FiltredPentagons;
            }
            else
            { MessageBox.Show("Нет исходного массива"); }
        }

        //Открыть
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Class1 = new List<Class1>();
            Class2 = new List<Class2>();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text file (*.txt)|*.txt";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == true)
            {
                StreamReader reader = new StreamReader(openFileDialog.FileName);
                string s;

                while ((s = reader.ReadLine()) != null)
                {
                    string[] arr = s.Split('|');
                    try
                    {
                        Class1.Add(new Class1(arr[0], arr[1], arr[2], arr[3]));
                    }
                    catch (Exception)
                    {
                        
                    }
                }
                reader.Close();

                if (Class2.Count == 0)
                {
                    DataGrid1.ItemsSource = null;
                    DataGrid1.ItemsSource = Class1;
                }
                else
                {
                    DataGrid1.ItemsSource = null;
                    DataGrid1.ItemsSource = Class2;
                }
            }

        }
        //Сохранение
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == true)
            {
                StreamWriter writer = new StreamWriter(saveFileDialog.FileName);
                if (obj1 == null)
                    for (int i = 0; i < Class1.Count; i++)
                    {
                        //rad ; perimeter ; area
                        writer.WriteLine("" + Class1[i].Dlina
                            + " | " + Class1[i].YravK + " | ");
                    }
                else
                    for (int i = 0; i < Class2.Count; i++)
                    {
                        //rad ; perimeter ; area
                        writer.WriteLine(""+ Class1[i].Dlina + " | " + Class1[i].YravK + " | " + Class1[i].YravB);
                    }
                writer.Close();
            }

        }

        

        //Выход
        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
