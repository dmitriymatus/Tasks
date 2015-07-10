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
using Epam_Task4_Library;

namespace Epam_Task4_WpfApplication
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

      private void Button1_Click(object sender, RoutedEventArgs e)
      {
         if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox3.Text != "" && TextBox1_Copy.Text != "" && TextBox2_Copy.Text != "" && TextBox3_Copy.Text != "")
         {
            Triangle a = new Triangle(Convert.ToInt16(TextBox1.Text), Convert.ToInt16(TextBox1_Copy.Text), Convert.ToInt16(TextBox2.Text), Convert.ToInt16(TextBox2_Copy.Text), Convert.ToInt16(TextBox3.Text), Convert.ToInt16(TextBox3_Copy.Text));
            if (a != null)
            {
               Label1.Content = "Такой треугольник существует!\n" + "Периметр треугольника: " + a.Perimeter() + "\nПлощадь треугольника: " + a.Square();
            }
            else
            {
               Label1.Content = "Такого треугольника не существует!\n";
            }
         }
      }
   }
}
