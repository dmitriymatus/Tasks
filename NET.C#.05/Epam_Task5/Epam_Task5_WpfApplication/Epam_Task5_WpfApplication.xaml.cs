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
using Epam_Task5_Library;

namespace Epam_Task5_WpfApplication
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
         if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox3.Text != "" && TextBox4.Text != "" && TextBox5.Text != "" && TextBox6.Text != "")
         {
            MyVector vect1 = new MyVector(Convert.ToDouble(TextBox1.Text), Convert.ToDouble(TextBox2.Text), Convert.ToDouble(TextBox3.Text));
            MyVector vect2 = new MyVector(Convert.ToDouble(TextBox4.Text), Convert.ToDouble(TextBox5.Text), Convert.ToDouble(TextBox6.Text));
            TextBox7.Text = Convert.ToString(vect1 ^ vect2);
            MyVector vect3 = vect1 + vect2;
            TextBox8.Text = Convert.ToString(vect3[0]) + "," + Convert.ToString(vect3[1]) + "," + Convert.ToString(vect3[2]);
            vect3 = vect1 - vect2;
            TextBox9.Text = Convert.ToString(vect3[0]) + "," + Convert.ToString(vect3[1]) + "," + Convert.ToString(vect3[2]);
            vect3 = vect1 * vect2;
            TextBox10.Text = Convert.ToString(vect3[0]) + "," + Convert.ToString(vect3[1]) + "," + Convert.ToString(vect3[2]);
         }
         else
         {
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
         }
      }
   }
}
