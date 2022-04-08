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
using System.IO;

namespace Рылеев_ПР10.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();
        }

        private void btnListFromFile_Click(object sender, RoutedEventArgs e)
        {
            lstInput.Items.Clear();
            StreamReader sr = new StreamReader(@"Строки3.txt", Encoding.UTF8);
            while (!sr.EndOfStream)
            {
                lstInput.Items.Add(sr.ReadLine());
            }
        }

        private void btnResult_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = lstInput.SelectedIndex;
                string str = (string)lstInput.Items[index];
                int count = 0;
                int i = 0;
                char[] a = { '.', ',', ':', ';', '?', '!', '-' };
                while (i < str.Length)
                {
                    if (a.Contains(str[i]))
                        count++;
                    i++;
                }
                txbResult.Text = count.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите нужную строку!\n" + "\nЕсли строк нет, то нажмите кнопку «Список из файла».", "Ошибка!");
            }
            StreamWriter sw = new StreamWriter(@"Результат.txt", true, Encoding.UTF8);
            int SelInd = Convert.ToInt32(lstInput.SelectedIndex);
            if (SelInd >= 0 && txbResult.Text != " ")
            {
                SelInd++;
                sw.WriteLine("Количество знаков препинания на третьем листе в строке №" + SelInd + ": " + txbResult.Text);
            }
            sw.Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            LstFrame.frmObject.Navigate(new Page2());
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы находитесь на последней странице!", "Ошибка!");
        }

        private void btnClearResult_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"Результат.txt", false, Encoding.UTF8);
            sw.Write("");
            sw.Close();
            txbResult.Text = "";
            lstInput.Items.Clear();
        }

        private void btnClearAll_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"Результат.txt", false, Encoding.UTF8);
            sw.Write("");
            sw.Close();
            txbResult.Text = "";
            lstInput.Items.Clear();
        }
    }
}
