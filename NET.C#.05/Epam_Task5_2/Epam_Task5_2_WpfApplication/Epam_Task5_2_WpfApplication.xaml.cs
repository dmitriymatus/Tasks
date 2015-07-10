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
using Epam_Task5_2_Library;

namespace Epam_Task5_2_WpfApplication
{
   /// <summary>
   /// Логика взаимодействия для MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      Multinomial prim, prim2;
      public MainWindow()
      {
         InitializeComponent();
      }

      private void Button1_Click(object sender, RoutedEventArgs e)
      {
               
      }

      private void Button2_Click(object sender, RoutedEventArgs e)
      {
         prim = new Multinomial(TextBox2.Text);
         Label1.Content = "Полученный многочлен:\n" + (string)prim; 
         prim2 = new Multinomial(TextBox4.Text);
         Label2.Content = "Полученный многочлен:\n" + (string)prim2;
         if (prim == prim2)
         {
            Label3.Content =  "Многочлены равны";
         }
         if (prim != prim2)
         {
            Label3.Content = "Многочлены не равны";
         }
      }
   }
}
