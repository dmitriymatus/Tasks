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
using Epam_Task3_Library;

namespace Epam_Task3_WpfApplication
{
   /// <summary>
   /// Логика взаимодействия для MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      double time1, time2;
      public MainWindow()
      {
         InitializeComponent();
      }

      private void Button1_Click(object sender, RoutedEventArgs e)
      {
         TextBox3.Text = GCDSearch.EuclideanAlgorithm(out time1,Convert.ToInt16(TextBox1.Text), Convert.ToInt16(TextBox2.Text)).ToString();
      }

      private void Button2_Click(object sender, RoutedEventArgs e)
      {
         TextBox6.Text = GCDSearch.BinaryGCDAlgorithm(out time2, Convert.ToInt16(TextBox4.Text), Convert.ToInt16(TextBox5.Text)).ToString();
      }

      private void Button3_Click(object sender, RoutedEventArgs e)
      {
         Window1 wind = new Window1();
         wind.Show();
         PointCollection c = new PointCollection();
         int i = GCDSearch.EuclideanAlgorithm(out time1, Convert.ToInt16(TextBox1_Copy.Text), Convert.ToInt16(TextBox2_Copy.Text));
         int j = GCDSearch.BinaryGCDAlgorithm(out time2, Convert.ToInt16(TextBox1_Copy.Text), Convert.ToInt16(TextBox2_Copy.Text));
         Point v = new Point(time1 * 1000, 1);
         Point z = new Point(time2 * 1000, 2);
         c.Add(v);
         c.Add(z);
         wind.Chart1.DataContext = c;
      }
   }
}